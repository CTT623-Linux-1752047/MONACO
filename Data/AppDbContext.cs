using Microsoft.EntityFrameworkCore;
using MONACO_ASP.Entities.Configuration;
using MONACO_ASP.Infracstructures;

namespace MONACO_ASP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(BrandConfig).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfig).Assembly);
        }

        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public override int SaveChanges()
        {
            OnModelBeforeOnSave();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnModelBeforeOnSave();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnModelBeforeOnSave()
        {
            var wSysDate = DateTime.UtcNow;
            Parallel.ForEach(ChangeTracker.Entries(), (entry) =>
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity is BaseEntity trackerAdd)
                        {
                            trackerAdd.CreatedYMD = wSysDate;
                        }
                        break;
                    case EntityState.Modified:
                        if (entry.Entity is IAuditEntity trackerEdit)
                        {
                            trackerEdit.UpdatedYMD = wSysDate;
                        }
                        break;

                }
            });
        }
    }
}
