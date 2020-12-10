using System.Threading.Tasks;

namespace Pazar.Statistics.Services.Statistics
{
    public interface IStatisticsService
    {
        Task<int> All();
    }
}
