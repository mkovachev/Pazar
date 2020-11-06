using Pazar.Ads.Data;
using Pazar.Ads.Data.Models;
using System.Threading.Tasks;

namespace Pazar.Ads.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly PazarDbContext db;
        public CategoryService(PazarDbContext db)
        {
            this.db = db;
        }
        public async Task<Category> Find(int id)
            => await this.db.Categories.FindAsync(id);
    }
}
