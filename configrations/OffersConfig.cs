
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTourism.Entities;

namespace DataAccessLayer.configrations
{
    public class OffersConfig : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {

                builder.HasKey(e => e.OfferId).HasName("PK__Offers");
                
                builder.Property(e => e.Description).HasMaxLength(255);
                builder.Property(e => e.DiscountValue).HasColumnType("decimal(18, 0)");
                builder.Property(e => e.Title).HasMaxLength(55);
                
                builder.HasOne(d => d.Trip).WithMany(p => p.Offers)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK__Offers__Trip_Id");
        }
    }
}
