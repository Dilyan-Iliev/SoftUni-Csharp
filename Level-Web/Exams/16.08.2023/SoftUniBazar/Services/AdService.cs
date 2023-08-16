namespace SoftUniBazar.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoftUniBazar.Data;
    using SoftUniBazar.Data.Models;
    using SoftUniBazar.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdService
        : IAdService
    {
        private readonly BazarDbContext dbContext;

        public AdService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddNewAdAsync(CreateAdViewModel model, string creatorId)
        {
            Ad ad = new ()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                CreatedOn = DateTime.UtcNow,
                CategoryId = model.CategoryId,
                OwnerId = creatorId
            };

            await this.dbContext.Ads.AddAsync(ad);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<int> AddToCartAsync(int id, string userId)
        {
            var ad = await this.dbContext
                .Ads
                .FirstOrDefaultAsync(a => a.Id == id);

            var user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (ad != null && user != null)
            {
                if (!this.dbContext.AdsBuyers
                    .Any(x => x.AdId == id && x.BuyerId == userId))
                {
                    var adBuyer = new AdBuyer()
                    {
                        AdId = id,
                        BuyerId = userId,
                        Ad = ad,
                        Buyer = user
                    };

                    await this.dbContext.AdsBuyers.AddAsync(adBuyer);
                    await this.dbContext.SaveChangesAsync();

                    return 1;
                }
            }

            return 0;
        }

        public async Task EditAdAsync(int id, EditAdViewModel model)
        {
            var adForEdit = await this.FindAdForEditAsync(id);

            if (adForEdit != null)
            {
                adForEdit.Name = model.Name;
                adForEdit.CategoryId = model.CategoryId;
                adForEdit.Description = model.Description;
                adForEdit.Price = model.Price;
                adForEdit.ImageUrl = model.ImageUrl;

                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<Ad> FindAdForEditAsync(int id)
        {
            return await this.dbContext
                .Ads
                .Include(a => a.Category)
                .Include(a => a.Owner)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<CartViewModel>> GetAdsInCartAsync(string userId)
        {
            return await this.dbContext
                .AdsBuyers
                .Where(a => a.BuyerId == userId)
                .Select(a => new CartViewModel()
                {
                    Id = a.Ad.Id,
                    ImageUrl = a.Ad.ImageUrl,
                    Description = a.Ad.Description,
                    Name = a.Ad.Name,
                    Price = a.Ad.Price,
                    Owner = a.Ad.Owner.Email,
                    Category = a.Ad.Category.Name,
                    CreatedOn = a.Ad.CreatedOn.ToString("dd-MM-yyyy HH:mm")
                    //в условието пише DateTime with format "yyyy-MM-dd H:mm
                    //но при примерните изображения формата е "dd-MM-yyyy HH:mm"
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllAdsViewModel>> GetAllAdsAsync()
        {
            return await dbContext
                .Ads
                .Select(a => new AllAdsViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Price = a.Price,
                    ImageUrl = a.ImageUrl,
                    Category = a.Category.Name,
                    Owner = a.Owner.Email,
                    CreatedOn = a.CreatedOn.ToString("dd-MM-yyyy HH:mm")
                    //в условието пише DateTime with format "yyyy-MM-dd H:mm
                    //но при примерните изображения формата е "dd-MM-yyyy HH:mm"
                })
                .ToListAsync();
        }

        public async Task RemoveFromCartAsync(int id, string userId)
        {
            var result = await this.dbContext
                .AdsBuyers
                .FirstOrDefaultAsync(x => x.AdId == id && x.BuyerId == userId);

            if (result != null)
            {
                this.dbContext.AdsBuyers.Remove(result);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SelectCategoryViewModel>> RetrieveCategoriesAsync()
        {
            return await this.dbContext
                .Categories
                .Select(c => new SelectCategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
    }
}
