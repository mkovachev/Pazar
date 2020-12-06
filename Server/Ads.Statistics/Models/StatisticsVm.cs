using Ads.Statistics.Data.Models;
using Pazar.Core.Mappings;

namespace Ads.Statistics.Models
{
    public class StatisticsVm : IMapFrom<AdsStatistics>
    {
        public int TotalAds { get; set; }
    }
}
