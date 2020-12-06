using Pazar.Ads.Data.Models;
using Pazar.Ads.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Services.Ads
{
    public interface IAdService
    {
        Task<Ad> Find(int id);

        Task<IEnumerable<AdVm>> All();

        Task<IEnumerable<MyAdsVm>> MyAds(string userId);

        Task<AdVm> Details(int id);

        Task<int> Total(AdsQuery query);

        Task<bool> Create(AdCreateIm input);

        Task<bool> Edit(AdEditIm input);

        Task<bool> Delete(int id);

        Task<bool> ChangeAvailability(int id);
    }
}
