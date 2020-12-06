using Pazar.Ads.Data.Interfaces;
using Pazar.Core.Services.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Pazar.Ads.Data
{
    public class AdsDataSeeder : IDataSeeder
    {
        private readonly IInitialCategories categories;
        private readonly PazarDbContext db;

        public AdsDataSeeder(IInitialCategories categories, PazarDbContext db)
        {
            this.categories = categories;
            this.db = db;
        }
        public void SeedData()
        {
            Task
               .Run(async () =>
               {

                   if (!this.db.Categories.Any())
                   {

                       var initialCategories = this.categories.GetInitialCategories();

                       foreach (var category in initialCategories)
                       {
                           await this.db.Categories.AddAsync(category);
                       }
                   }

                   await this.db.SaveChangesAsync();
               })
               .GetAwaiter()
               .GetResult();
        }
    }
}
