using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meetzy.Domain;

namespace Meetzy.Persistence.Configurations;

public class CommunityConfiguration : IEntityTypeConfiguration<Community>
{
    public void Configure(EntityTypeBuilder<Community> builder)
    {
        builder.HasKey(c => c.CommunityId);

        builder.HasOne(c => c.Creator)
               .WithMany()
               .HasForeignKey(c => c.CreatedBy)
               .OnDelete(DeleteBehavior.NoAction);
    }
}