using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meetzy.Domain;

namespace Meetzy.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.UserId).ValueGeneratedNever();
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            // Database-level constraint: El Email debe contener'@'
            builder.HasCheckConstraint("CK_Users_Email_AtSymbol", "CHARINDEX('@', Email) > 0");

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.Phone);

            builder.Property(u => u.BirthDate);
            builder.Property(u => u.ProfilePhoto);

            builder.Property(u => u.CreatedAt)
                .IsRequired();
            // Relationships
            builder.HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}