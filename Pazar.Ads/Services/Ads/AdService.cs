using Pazar.Ads.Features.Ads;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Services.Ads
{
    public class AdService : IAdService
    {
        public Task Create()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Edit(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<AdVm>> GetAll(AdsDto query)
        {
            throw new System.NotImplementedException();
        }

        public Task<AdVm> GetDetails(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<MyAdsVm>> GetMyAds(int dealerId, AdsDto query)
        {
            throw new System.NotImplementedException();
        }
    }
}
