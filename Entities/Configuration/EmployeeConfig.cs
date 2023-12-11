using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MONACO_ASP.Entities.Configuration
{
    public class EmployeeConfig : BaseEntityConfig<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.ToTable("Employees");

            builder.HasKey(c => c.Id);
            builder.Property(p => p.Username)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Firstname)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Lastname)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Middlename)
                .IsRequired()
                .HasMaxLength(200);
            
            builder.Property(p => p.Gender);

            builder.Property(p => p.Address);
            
            builder.Property(p => p.Birthday);
            
            builder.Property(p => p.CreatedYMD)
                .HasDefaultValueSql("GETDATE()");
            
            builder.Property(p => p.CreatedAt);

            builder.Property(p => p.UpdatedYMD);

            builder.Property(p => p.DeletedAt);

            builder.Property(p => p.DeletedYMD);

            builder.Property(p => p.IsDeleted)
                 .HasDefaultValue(false);

            builder.Property(p => p.UpdatedAt);
            
            builder.Property(p => p.Password);
            
            builder.Property(p => p.Position)
                .HasDefaultValue(1); ;

            builder.Property(p => p.IsActived)
                .HasDefaultValue(true);

        }
    }
}
