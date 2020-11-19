using Pazar.Ads.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Services.Categories
{
    public interface ICategoryService
    {
        Task<CategoryDetailsVm> FindById(int id);

        Task<IEnumerable<CategoryVm>> GetAll();
    }
}
