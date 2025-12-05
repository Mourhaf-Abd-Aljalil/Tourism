
using DataAccessLayer.configrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectTourism.ClassDTO;
using ProjectTourism.Entities;
using System;



namespace ProjectTourism.Data
{
    public class AppDbContext : DbContext
    {
        public  DbSet<Activity>? Activities { get; set; }
        
         public DbSet<TripDTO>? TripDTO { get; set; }

        public DbSet<Attraction>? Attractions { get; set; }

        public  DbSet<Booking>? Bookings { get; set; }

        public  DbSet<Offer>? Offers { get; set; }

        public  DbSet<Payment>? Payments { get; set; }

        public  DbSet<Review>? Reviews { get; set; }

        public  DbSet<Trip> Trips { get; set; }

        public  DbSet<TripAttraction>? TripAttractions { get; set; }

        public DbSet<User>? Users { get; set; }

            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionBuilder)
        {
            base.OnConfiguring(OptionBuilder);

            OptionBuilder.UseSqlServer("Server = . ; Database = DbTourism ; Integrated Security = SSPI ; TrustServerCertificate = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<TripDTO>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersConfig).Assembly);  
        }


    }
}
