using Microsoft.EntityFrameworkCore;
using Pazar.Ads.Data.Configurations;
using Pazar.Ads.Data.Models;
using Pazar.Core.Data;
using Pazar.Core.Interfaces;
using Pazar.Core.Services.Identity;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Pazar.Ads.Data
{
    public class PazarDbContext : MessageDbContext
    {
        private readonly IDateTime dateTime;
        private readonly ILoggedUserService user;

        public PazarDbContext(
            DbContextOptions<PazarDbContext> options,
            IDateTime dateTime,
            ILoggedUserService user)
            : base(options)
        {
            this.dateTime = dateTime;
            this.user = user;
        }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<Category> Categories { get; set; }

        //public DbSet<Image> Images { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var filtered =
                ChangeTracker
                .Entries<AuditableEntity>()
                .Where(e => e.Entity is AuditableEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified)
                        || e.State == EntityState.Deleted);

            foreach (var entry in filtered)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = user.Id;
                        entry.Entity.CreatedOn = dateTime.UtcNow();
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = user.Id;
                        entry.Entity.ModifiedOn = dateTime.UtcNow();
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeleteBy = user.Id;
                        entry.Entity.DeletedOn = dateTime.UtcNow();
                        entry.Entity.IsDeleted = true;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
