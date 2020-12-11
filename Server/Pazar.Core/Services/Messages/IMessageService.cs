using Pazar.Core.Messages.Ads;
using System.Threading.Tasks;

namespace Pazar.Core.Services.Messages
{
    public interface IMessageService
    {
        Task<bool> IsDuplicated(
            object messageData,
            string propertyFilter,
            object identifier);

        Task<bool> IsDuplicated(AdCreatedMessage message);
    }
}
