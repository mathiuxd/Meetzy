using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meetzy.Domain;

namespace Meetzy.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");

            builder.HasKey(e => e.EventId);
            builder.Property(e => e.EventId).ValueGeneratedNever();

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Description)
                .HasMaxLength(1000);

            builder.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.EventDateTime)
                .IsRequired();

            builder.Property(e => e.MaxAttendees);

            builder.Property(e => e.CreatorId)
                .IsRequired();

            builder.Property(e => e.CommunityId);

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            // Relationships
            builder.HasMany(e => e.Attendees)
                .WithOne(a => a.Event)
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Comments)
                .WithOne(c => c.Event)
                .HasForeignKey(c => c.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // Creator relationship (if User mapped)
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Community relationship
            builder.HasOne<Community>()
                .WithMany()
                .HasForeignKey(e => e.CommunityId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
