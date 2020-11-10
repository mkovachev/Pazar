using Pazar.Ads.Data.Interfaces;
using Pazar.Core.Data;
using System.Linq;

namespace Pazar.Ads.Data
{
    public class DataSeeder : IDataSeeder
    {
        private readonly IInitialCategories categories;
        private readonly PazarDbContext db;

        public DataSeeder(IInitialCategories categories, PazarDbContext db)
        {
            this.categories = categories;
            this.db = db;
        }
        public void SeedData()
        {
            var initialCategories = this.categories.GetInitialCategories();

            if (!this.db.Categories.Any())
            {
                foreach (var entity in initialCategories)
                {
                    this.db.Add(entity);
                }

                this.db.SaveChanges();
            }
        }
    }
}