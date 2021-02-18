using LEMV.Domain.Entities;
using LEMV.Domain.Entities.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LEMV.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<News> News { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var trackedEntities = ChangeTracker.Entries<Entity>();
            var now = DateTime.Now;
            foreach (var entity in trackedEntities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property(x => x.CreatedAt).CurrentValue = now;
                    entity.Property(x => x.LastMofication).CurrentValue = now;
                }

                if (entity.State == EntityState.Modified)
                {
                    entity.Property(x => x.CreatedAt).IsModified = false;
                    entity.Property(x => x.LastMofication).CurrentValue = now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
