using Microsoft.EntityFrameworkCore;
using Pazar.Ads.Data.Models;
using Pazar.Core.Interfaces;
using Pazar.Core.Services.Identity;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Pazar.Ads.Data
{
    public class PazarDbContext : DbContext
    {
        private readonly IUser userService;
        private readonly IDateTime dateTime;

        public PazarDbContext(DbContextOptions<PazarDbContext> options, IUser userService, IDateTime dateTime)
            : base(options)
        {
            this.userService = userService;
            this.dateTime = dateTime;
        }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Image> Images { get; set; }

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
                        entry.Entity.CreatedBy = userService.Id;
                        entry.Entity.CreatedOn = dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = userService.Id;
                        entry.Entity.ModifiedOn = dateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeleteBy = userService.Id;
                        entry.Entity.DeletedOn = dateTime.Now;
                        entry.Entity.IsDeleted = true;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
