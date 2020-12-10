using Pazar.Core.Mappings;
using Pazar.Statistics.Data.Models;

namespace Pazar.Statistics.Models
{
    public class AdsVm : IMapFrom<Ad>
    {
        public int Total { get; set; }
    }
}
