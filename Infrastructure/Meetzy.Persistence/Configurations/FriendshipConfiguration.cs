using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;  
using Meetzy.Domain;

namespace Meetzy.Persistence.Configurations
{
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.ToTable("Friendships");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedNever();
            builder.Property(f => f.CreatedAt)
                .IsRequired();
            // Relationships
            builder.HasOne(f => f.UserSends)
                .WithMany(u => u.FriendshipsInitiated)
                .HasForeignKey(f => f.User1Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.User2)
                .WithMany(u => u.UserReceived)
                .HasForeignKey(f => f.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}