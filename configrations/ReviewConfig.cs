
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTourism.Entities;

namespace DataAccessLayer.configrations
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {

         
                builder.HasKey(e => e.ReviewId).HasName("PK__Review");
                
                builder.ToTable("Review");
                
                builder.Property(e => e.ReviewId).HasColumnName("Review_Id");
                builder.Property(e => e.Comment).HasMaxLength(255);
                builder.Property(e => e.ReviewDate).HasColumnType("datetime");
                builder.Property(e => e.TripId).HasColumnName("Trip_Id");
                
                builder.HasOne(d => d.Trip).WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK__Review__Trip_Id");
           

        }
    }
}
