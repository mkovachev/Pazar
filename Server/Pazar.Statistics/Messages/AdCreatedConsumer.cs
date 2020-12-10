using MassTransit;
using Microsoft.EntityFrameworkCore;
using Pazar.Core.Data.Models;
using Pazar.Core.Messages.Ads;
using Pazar.Core.Services.Messages;
using Pazar.Statistics.Data;
using System.Threading.Tasks;

namespace Pazar.Statistics.Messages
{
    public class AdCreatedConsumer : IConsumer<AdCreatedMessage>
    {
        private readonly StatisticsDbContext db;
        private readonly IMessageService messages;

        public AdCreatedConsumer(StatisticsDbContext db, IMessageService messages)
        {
            this.db = db;
            this.messages = messages;
        }

        public async Task Consume(ConsumeContext<AdCreatedMessage> context)
        {
            var message = context.Message;

            var isDuplicated = await this.messages.IsDuplicated(
                message,
                nameof(AdCreatedMessage.Id),
                message.Id);

            if (isDuplicated)
            {
                return;
            }

            var ads = await this.db.Ads.SingleOrDefaultAsync();

            ads.Total++; // Todo thread safe

            var dbMessage = new Message(message);

            dbMessage.MarkAsPublished();

            this.db.Messages.Add(dbMessage);

            await this.db.SaveChangesAsync();
        }
    }
}
