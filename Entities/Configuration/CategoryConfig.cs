using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MONACO_ASP.Entities.Configuration
{
    public class CategoryConfig : BaseEntityConfig<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(p => p.name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
