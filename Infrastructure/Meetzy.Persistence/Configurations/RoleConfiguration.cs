using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meetzy.Domain;

namespace Meetzy.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(r => r.RoleId);
            builder.Property(r => r.RoleId).ValueGeneratedNever();
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(r => r.Description);
            // Configurar la relacion con RolePermission
            builder.HasMany(r => r.Permissions)
                .WithOne(rp => rp.Role)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}