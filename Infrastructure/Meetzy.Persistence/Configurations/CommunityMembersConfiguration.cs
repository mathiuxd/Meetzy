using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meetzy.Domain;

namespace Meetzy.Persistence.Configurations
{
    public class CommunityMembersConfiguration : IEntityTypeConfiguration<CommunityMembers>
    {
        public void Configure(EntityTypeBuilder<CommunityMembers> builder)
            {
            builder.ToTable("CommunityMember");
            builder.HasKey(cm => cm.Id);
            builder.Property(cm => cm.Id).ValueGeneratedNever();
            builder.Property(cm => cm.JoinedAt)
                .IsRequired();
            // Relationships
            builder.HasOne(cm => cm.Community)
                .WithMany(c => c.Members)
                .HasForeignKey(cm => cm.CommunityId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(cm => cm.User)
                .WithMany(u => u.CommunityMemberships)
                .HasForeignKey(cm => cm.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}