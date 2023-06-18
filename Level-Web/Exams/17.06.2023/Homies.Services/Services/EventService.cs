namespace Homies.Services.Services
{
    using Homies.Core;
    using Homies.Core.Entities;
    using Homies.Services.Contracts;
    using Homies.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EventService
        : IEventService
    {
        private readonly HomiesDbContext context;

        public EventService(HomiesDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(AddEventViewModel model, string organiserId)
        {
            var newEvent = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                OrganiserId = organiserId,
                CreatedOn = DateTime.UtcNow,
            };

            await this.context.Events.AddAsync(newEvent);
            await this.context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, EditEventViewModel model)
        {
            var eventForEdit = await this.FindByIdAsync(id);

            if (eventForEdit != null)
            {
                eventForEdit.Name = model.Name;
                eventForEdit.Description = model.Description;
                eventForEdit.Start = model.Start;
                eventForEdit.End = model.End;
                eventForEdit.TypeId = model.TypeId;

                await this.context.SaveChangesAsync();
            };
        }

        public async Task<Event?> FindByIdAsync(int id)
        {
            return await this.context
                .Events
                .Include(e => e.Organiser)
                .Include(e => e.Type)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<AllEventsViewModel>> GetAllForCreatorAsync()
        {
            return await this.context
                .Events
                .Select(e => new AllEventsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.Email
                })
                .ToListAsync();
        }

        public async Task<EventDetailsViewModel> GetDetailsAsync(int id)
        {
            var eventDetails = await this.FindByIdAsync(id);

            if (eventDetails != null)
            {
                return new EventDetailsViewModel()
                {
                    Id = eventDetails.Id,
                    Name = eventDetails.Name,
                    Description = eventDetails.Description,
                    CreatedOn = eventDetails.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Start = eventDetails.Start.ToString("yyyy-MM-dd H:mm"),
                    End = eventDetails.End.ToString("yyyy-MM-dd H:mm"),
                    Type = eventDetails.Type.Name,
                    Organiser = eventDetails.Organiser.Email
                };
            }

            return null;
        }

        public async Task<ICollection<JoinedEventsViewModel>> GetAllJoinedEventsAsync(string userId)
        {
            return await this.context
                .EventsParticipants
                .Include(x => x.Event)
                    .ThenInclude(e => e.Type)
                .Include(x => x.Event.Organiser)
                .Where(x => x.HelperId == userId)
                .Select(x => new JoinedEventsViewModel()
                {
                    Id = x.EventId,
                    Name = x.Event.Name,
                    Start = x.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = x.Event.Type.Name,
                    Organiser = x.Event.Organiser.Email,
                })
                .ToListAsync();
        }

        public async Task<ICollection<TypeViewModel>> GetEventTypesAsync()
        {
            return await this.context
                .Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }

        public async Task<int> JoinAsync(int id, string userId)
        {
            var eventToJoin = await this.context
                .Events
                .FirstOrDefaultAsync(e => e.Id == id);

            var user = await this.context
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (!this.context.EventsParticipants
                .Any(x => x.EventId == id && x.HelperId == userId))
            {
                var eventParticipant = new EventParticipant()
                {
                    EventId = id,
                    Event = eventToJoin,
                    HelperId = userId,
                    Helper = user
                };

                await this.context.EventsParticipants.AddAsync(eventParticipant);
                await this.context.SaveChangesAsync();

                return 1;
            }
            else
            {
                return 0;
            }
        }

        public async Task LeaveAsync(int id, string userId)
        {
            var result = await this.context
                .EventsParticipants
                .FirstOrDefaultAsync(x => x.EventId == id && x.HelperId == userId);

            if (result != null)
            {
                this.context.EventsParticipants.Remove(result);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
