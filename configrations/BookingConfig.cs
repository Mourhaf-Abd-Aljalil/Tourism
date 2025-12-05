
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTourism.Entities;

namespace DataAccessLayer.configrations
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
                builder.HasKey(e => e.BookingId).HasName("PK__Booking");
                
                builder.ToTable("Booking");
                
                builder.Property(e => e.BookingId).HasColumnName("Booking_Id");
                builder.Property(e => e.BookingDate).HasColumnType("datetime");
                builder.Property(e => e.CostBooking).HasColumnType("decimal(18, 0)");
                builder.Property(e => e.Status).HasColumnName("status");
                builder.Property(e => e.TripId).HasColumnName("Trip_Id");
                builder.Property(e => e.UserId).HasColumnName("User_Id");
                
                builder.HasOne(d => d.Trip).WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK__Booking__Trip_Id");

                builder.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Booking__User_Id");
        }
    }
}
