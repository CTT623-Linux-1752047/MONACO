using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MONACO_ASP.Entities.Configuration
{
    public class BrandConfig : BaseEntityConfig<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            base.Configure(builder);

            builder.ToTable("Brands");

            builder.HasKey(c => c.Id);

            builder.Property(p => p.name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.description)
                .IsRequired()
                .HasDefaultValue(null)
                .IsUnicode(false);

            builder.Property(p => p.since)
                .HasDefaultValue(null);

            builder.Property(p => p.img_logo)
                .HasDefaultValue(null);

            builder.Property(p => p.img_background)
                .HasDefaultValue(null);
        }
    }
}
