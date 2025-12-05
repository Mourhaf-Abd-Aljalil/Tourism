
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTourism.Entities;

namespace DataAccessLayer.configrations
{
    public class ActivityConfig : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
          
                builder.HasKey(e => e.ActivityId).HasName("ActivityID");
                
                builder.ToTable("Activity");
                
                builder.Property(e => e.ActivityId).HasColumnName("ActivityID");
                builder.Property(e => e.ActivityName)
                    .HasMaxLength(254)
                    .HasColumnName("Activity_Name");
                builder.Property(e => e.Description).HasMaxLength(255);
                builder.Property(e => e.Location).HasMaxLength(255);
                builder.Property(e => e.TripId).HasColumnName("Trip_ID");

                builder.HasOne(d => d.Trip).WithMany(p => p.Activities)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK__Activity__Trip_ID");

        }
    }
}
