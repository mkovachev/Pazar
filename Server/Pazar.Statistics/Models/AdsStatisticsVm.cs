using Pazar.Core.Mappings;
using Pazar.Statistics.Data.Models;

namespace Pazar.Statistics.Models
{
    public class AdsStatisticsVm : IMapFrom<AdsStatistics>
    {
        public int TotalAds { get; set; }
    }
}
