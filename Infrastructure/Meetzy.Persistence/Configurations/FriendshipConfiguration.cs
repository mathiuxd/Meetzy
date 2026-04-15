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
         
            // Relationships
            builder.HasOne(f => f.UserSend)
               .WithMany() 
               .HasForeignKey(f => f.UserSendId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.UserReceives)
                .WithMany()
                .HasForeignKey(f => f.UserReceivesId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}