using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meetzy.Domain;

namespace Meetzy.Persistence.Configurations;

public class CommunityMemberConfiguration : IEntityTypeConfiguration<CommunityMember>
{
    public void Configure(EntityTypeBuilder<CommunityMember> builder)
    {
        builder.HasKey(cm => cm.Id);

        builder.HasOne(cm => cm.Community)
               .WithMany()
               .HasForeignKey(cm => cm.CommunityId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(cm => cm.User)
               .WithMany()
               .HasForeignKey(cm => cm.UserId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}