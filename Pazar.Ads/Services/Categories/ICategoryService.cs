using Pazar.Ads.Data.Models;
using System.Threading.Tasks;

namespace Pazar.Ads.Services.Categories
{
    public interface ICategoryService
    {
        Task<Category> Find(int id);
    }
}
