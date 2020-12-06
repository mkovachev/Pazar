using Ads.Statistics.Data.Models;
using Pazar.Core.Mappings;

namespace Ads.Statistics.Models
{
    public class AdsStatisticsVm : IMapFrom<AdsStatistics>
    {
        public int TotalAds { get; set; }
    }
}
