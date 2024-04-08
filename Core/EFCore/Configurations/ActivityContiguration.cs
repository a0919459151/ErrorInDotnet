using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EFCore.Configurations;

public class ActivityContiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasOne(x => x.ActivityCategory)
            .WithMany(x => x!.Activities)
            .HasForeignKey(x => x.ActivityCategoryId);
    }
}
