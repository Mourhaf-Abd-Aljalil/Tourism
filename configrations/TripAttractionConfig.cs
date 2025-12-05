
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTourism.Entities;

namespace DataAccessLayer.configrations
{
    public class TripAttractionConfig : IEntityTypeConfiguration<TripAttraction>
    {
        public void Configure(EntityTypeBuilder<TripAttraction> builder)
        {

                 builder.HasKey(e => e.TripAttractionId).HasName("PK__Trip_Att");

                builder.ToTable("Trip_Attraction");

                builder.Property(e => e.TripAttractionId).HasColumnName("Trip_Attraction_Id");
                builder.Property(e => e.AttractionId).HasColumnName("Attraction_Id");
                builder.Property(e => e.TripId).HasColumnName("Trip_Id");

                builder.HasOne(d => d.Attraction).WithMany(p => p.TripAttractions)
                    .HasForeignKey(d => d.AttractionId)
                    .HasConstraintName("FK__Trip_Attr__Attra");

                builder.HasOne(d => d.Trip).WithMany(p => p.TripAttractions)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK__Trip_Attr__Trip");
            

        }
    }
}
