using Pazar.Statistics.Data;
using MassTransit;
using Pazar.Core.Data.Models;
using Pazar.Core.Messages.Ads;
using Pazar.Core.Services.Messages;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

            var statistics = await this.db.AdsStatistics.SingleOrDefaultAsync();

            statistics.TotalAds++; // Todo thread safe

            var dataMessage = new Message(message);

            dataMessage.MarkAsPublished();

            this.db.Messages.Add(dataMessage);

            await this.db.SaveChangesAsync();
        }
    }
}
