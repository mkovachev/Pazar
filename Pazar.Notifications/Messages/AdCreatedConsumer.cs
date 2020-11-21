using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Pazar.Core.Messages.Ads;
using System.Threading.Tasks;

namespace Pazar.Notifications.Messages
{
    using static Constants;
    public class AdCreatedConsumer : IConsumer<AdCreatedMessage>
    {
        private readonly IHubContext<NotificationsHub> hub;

        public AdCreatedConsumer(IHubContext<NotificationsHub> hub)
        {
            this.hub = hub;
        }

        public async Task Consume(ConsumeContext<AdCreatedMessage> context)
            => await this.hub
                    .Clients
                    .Groups(AuthenticatedUsersGroup)
                    .SendAsync(ReceiveNotificationEndpoint, context.Message);
    }
}
