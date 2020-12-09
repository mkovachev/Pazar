using Pazar.Statistics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Statistics.Services.AdsViews
{
    public interface IAdsViewService
    {
        Task<int> TotalViews(int Id);

        Task<IEnumerable<AdsVm>> TotalViews(IEnumerable<int> ids);
    }
}
