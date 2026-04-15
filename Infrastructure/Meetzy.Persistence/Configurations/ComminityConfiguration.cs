using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meetzy.Domain;


namespace Meetzy.Persistence.Configurations
{
    public class CommunityConfiguration : IEntityTypeConfiguration<Community>
    {
        public void Configure(EntityTypeBuilder<Community> builder)
        {
            builder.ToTable("Communities");

            builder.HasKey(c => c.CommunityId);
            builder.Property(c => c.CommunityId).ValueGeneratedNever();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);

           /* builder.Property(c => c.Description)
                .HasMaxLength(1000);*/

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            // Relationships
            builder.HasMany(c => c.Members)
                .WithOne(m => m.Community)
                .HasForeignKey(m => m.CommunityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}