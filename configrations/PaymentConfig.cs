
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTourism.Entities;

namespace DataAccessLayer.configrations
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {

          
                builder.HasKey(e => e.PaymentId).HasName("PK__Payment");
                
                builder.ToTable("Payment");
                
                builder.Property(e => e.PaymentId).HasColumnName("Payment_Id");
                builder.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
                builder.Property(e => e.BookingId).HasColumnName("Booking_Id");
                builder.Property(e => e.PaymentDate).HasColumnType("datetime");
                builder.Property(e => e.PaymentMethod).HasMaxLength(255);
                
                builder.HasOne(d => d.Booking).WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Payment__Booking");
        }
    }
}
