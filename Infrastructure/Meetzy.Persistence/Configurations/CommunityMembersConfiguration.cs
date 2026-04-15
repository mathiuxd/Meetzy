using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meetzy.Domain;

namespace Meetzy.Persistence.Configurations
{
    public class CommunityMembersConfiguration : IEntityTypeConfiguration<CommunityMember>
    {
        public void Configure(EntityTypeBuilder<CommunityMember> builder)
        {
            builder.ToTable("CommunityMembers");
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
                .WithMany()
                .HasForeignKey(cm => cm.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}