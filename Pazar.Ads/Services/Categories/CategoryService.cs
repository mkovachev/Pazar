using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pazar.Ads.Data;
using Pazar.Ads.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pazar.Ads.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly PazarDbContext db;
        private readonly IMapper mapper;

        public CategoryService(PazarDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<CategoryDetailsVm> FindById(int id)
            => await this.db.Categories
                             .Where(c => c.Id == id)
                             .ProjectTo<CategoryDetailsVm>(this.mapper.ConfigurationProvider)
                             .FirstOrDefaultAsync();

        public async Task<IEnumerable<CategoryVm>> GetAll()
            => await this.db.Categories
                            .OrderBy(c => c.Name)
                            .ProjectTo<CategoryVm>(this.mapper.ConfigurationProvider)
                            .ToListAsync();
    }
}
