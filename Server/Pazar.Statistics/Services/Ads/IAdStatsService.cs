using Pazar.Statistics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Statistics.Services.Ads
{
    public interface IAdStatsService
    {
        Task<int> TotalViews(int Id);

        Task<IEnumerable<AdVm>> TotalViews(IEnumerable<int> ids);
    }
}
