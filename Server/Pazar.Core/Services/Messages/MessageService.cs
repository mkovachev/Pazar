using Microsoft.EntityFrameworkCore;
using Pazar.Core.Data;
using System;
using System.Threading.Tasks;

namespace Pazar.Core.Services.Messages
{
    public class MessageService : IMessageService
    {
        private readonly MessageDbContext db;

        public MessageService(DbContext db)
            => this.db = db as MessageDbContext
                ?? throw new InvalidOperationException($"Messages can only be used with a {nameof(MessageDbContext)}.");

        public async Task<bool> IsDuplicated(
            object messageData,
            string propertyFilter,
            object identifier)
        {
            var messageType = messageData.GetType();

            return await this.db
                .Messages
                .FromSqlRaw($"SELECT * FROM Messages WHERE Type = '{messageType.AssemblyQualifiedName}' AND JSON_VALUE(serializedData, '$.{propertyFilter}') = {identifier}")
                .AnyAsync();
        }

        //public async Task<bool> IsDuplicated(AdCreatedMessage message)
        //    => await this.db.Messages.AnyAsync(m => m.Id == message.Id);
    }
}
