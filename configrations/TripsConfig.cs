
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTourism.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.configrations
{
    public class TripsConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {

                builder.HasKey(e => e.TripId).HasName("PK__Trip");

                builder.ToTable("Trip");

                builder.Property(e => e.TripId).HasColumnName("TripID");
                builder.Property(e => e.Description).HasMaxLength(255);
                builder.Property(e => e.EndDate).HasColumnType("datetime");
                builder.Property(e => e.Price).HasColumnType("decimal(18, 0)");
                builder.Property(e => e.StartDate).HasColumnType("datetime");
                builder.Property(e => e.Title).HasMaxLength(55);
           
        }
    }
}
