using Pazar.Ads.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Services.Categories
{
    public interface ICategoryService
    {
        Task<CategoryVm> Find(int id);

        Task<IEnumerable<CategoryVm>> All();

        Task<IEnumerable<AdVm>> Ads(int id);
    }
}
