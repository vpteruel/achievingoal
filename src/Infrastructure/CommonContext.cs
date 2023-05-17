using Domain.Entities.Common;
using Infrastructure.Mappings.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class CommonContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }

        public DbSet<User> Users { get; set; }

        public CommonContext() =>
            DisableChangeTrackers();

        public CommonContext(DbContextOptions<CommonContext> options)
            : base(options) =>
            DisableChangeTrackers();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        private void DisableChangeTrackers()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.LazyLoadingEnabled = false;
        }
    }
}