using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MONACO_ASP.Entities.Configuration
{
	public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>
		where TEntity : class
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.Property("CreatedAt")
				.HasDefaultValue(null);

			builder.Property("UpdatedAt")
				.HasDefaultValue(null);

			builder.Property("CreatedYMD")
				.HasDefaultValue(null)
                .HasDefaultValueSql("GETDATE()");

			builder.Property("UpdatedYMD")
				.HasDefaultValue(null)
                .HasDefaultValueSql("GETDATE()");
		}
	}
}


