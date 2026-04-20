using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meetzy.Domain;

namespace Meetzy.Persistence.Configurations;

public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
{
    public void Configure(EntityTypeBuilder<Friendship> builder)
    {
        builder.HasKey(f => f.Id);

        builder.HasOne(f => f.UserSend)
               .WithMany()
               .HasForeignKey(f => f.UserSendId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(f => f.UserReceives)
               .WithMany()
               .HasForeignKey(f => f.UserReceivesId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}