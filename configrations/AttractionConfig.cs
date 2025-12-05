
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTourism.Entities;

namespace DataAccessLayer.configrations
{
    public class AttractionConfig : IEntityTypeConfiguration<Attraction>
    {
        public void Configure(EntityTypeBuilder<Attraction> builder)
        {
                builder.HasKey(e => e.AttractionId).HasName("AttractionId");
                
                builder.ToTable("Attraction");
                
                builder.Property(e => e.AttractionId).HasColumnName("Attraction_Id");
                builder.Property(e => e.AttractionName)
                    .HasMaxLength(100)
                    .HasColumnName("Attraction_Name");
                builder.Property(e => e.Description).HasMaxLength(255);
                builder.Property(e => e.Location).HasMaxLength(255);

        }
    }
}
