using Microsoft.EntityFrameworkCore;
using Pazar.Core.Data.Configurations;
using Pazar.Core.Data.Models;
using System.Reflection;

namespace Pazar.Core.Data
{
    public abstract class MessageDbContext : DbContext
    {
        protected MessageDbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<Message>? Messages { get; set; }

        protected abstract Assembly ConfigurationsAssembly { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());

            builder.ApplyConfigurationsFromAssembly(this.ConfigurationsAssembly);

            base.OnModelCreating(builder);
        }
    }
}
