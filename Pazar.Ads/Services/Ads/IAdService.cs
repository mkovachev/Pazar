using Pazar.Ads.Features.Ads;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Services.Ads
{
    public interface IAdService
    {
        Task<AdVm> GetDetails(int id);

        Task Create();

        Task Edit(int id);

        Task<bool> Delete(int id);

        Task<IEnumerable<AdVm>> GetAll(AdsDto query);

        Task<IEnumerable<MyAdsVm>> GetMyAds(int userId, AdsDto query);

    }
}
