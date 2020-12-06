using Ads.Statistics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ads.Statistics.Services.Ads
{
    public interface IAdService
    {
        Task<int> TotalViews(int Id);

        Task<IEnumerable<AdVm>> TotalViews(IEnumerable<int> ids);
    }
}
