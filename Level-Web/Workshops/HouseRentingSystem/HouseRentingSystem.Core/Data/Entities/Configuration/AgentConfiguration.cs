namespace HouseRentingSystem.Core.Data.Entities.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class AgentConfiguration
        : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasData(SeedAgents());
        }

        private List<Agent> SeedAgents()
        {
            return new List<Agent>()
            {
                new Agent()
                {
                    Id = 1,
                    PhoneNumber = "+359888888888",
                    UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                }
            };
        }
    }
}
