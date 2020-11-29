using Pazar.Ads.Data.Models;
using Pazar.Ads.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Services.Ads
{
    public interface IAdService
    {
        Task<Ad> FindById(int id);

        Task<IEnumerable<AdVm>> GetAll();

        Task<IEnumerable<AdVm>> GetAdsPerCategory(int id);

        Task<IEnumerable<MyAdsVm>> MyAds(string userId);

        Task<AdVm> GetDetails(int id);

        Task<int> Total(AdsQuery query);


        Task<int> Create(AdIm input);

        Task<int> Edit(int id);

        Task<bool> Delete(int id);
    }
}
