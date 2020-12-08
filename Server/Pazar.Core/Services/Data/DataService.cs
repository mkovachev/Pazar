namespace Pazar.Core.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Messages;
    using Microsoft.EntityFrameworkCore;
    using Pazar.Core.Data;
    using Pazar.Core.Data.Models;

    public abstract class DataService<TEntity> : IDataService<TEntity>
        where TEntity : class
    {
        protected DataService(DbContext db, IPublisher publisher)
        {
            this.Db = db;
            this.Publisher = publisher;
        }

        protected DbContext Db { get; }

        protected IPublisher Publisher { get; }

        protected IQueryable<TEntity> All() => this.Db.Set<TEntity>();

        public void Add(TEntity entity)
            => this.Db.Add(entity);

        public async Task Save(params object[] messages)
        {
            var dataMessages = messages
                .ToDictionary(data => data, data => new Message(data));

            if (this.Db is MessageDbContext)
            {
                foreach (var (_, message) in dataMessages)
                {
                    this.Db.Add(message);
                }
            }

            await this.Db.SaveChangesAsync();

            if (this.Db is MessageDbContext)
            {
                foreach (var (data, message) in dataMessages)
                {
                    await this.Publisher.Publish(data);

                    message.MarkAsPublished();

                    await this.Db.SaveChangesAsync();
                }
            }
        }
    }
}
