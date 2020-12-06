using Pazar.Statistics.Data.Models;
using Pazar.Core.Mappings;

namespace Pazar.Statistics.Models
{
    public class AdsStatisticsVm : IMapFrom<AdsStatistics>
    {
        public int TotalAds { get; set; }
    }
}
