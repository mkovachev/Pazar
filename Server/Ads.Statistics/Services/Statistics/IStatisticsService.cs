using Ads.Statistics.Models;
using System.Threading.Tasks;

namespace Ads.Statistics.Services.Statistics
{
    public interface IStatisticsService
    {
        Task<StatisticsVm> AdsOverview();
    }
}
