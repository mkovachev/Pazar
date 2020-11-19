using Pazar.Ads.Features.Categories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Services.Categories
{
    public interface ICategoryService
    {
        Task<CategoryDetailsVm> FindById(int categoryId);

        Task<IEnumerable<CategoryVm>> GetAll();
    }
}
