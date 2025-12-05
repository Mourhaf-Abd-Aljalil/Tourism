namespace ProjectTourism.Entities
{
    public class Trip
    {
        public int TripId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? Price { get; set; }

        public  ICollection<Activity> Activities { get; set; } = new List<Activity>();

        public  ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public  ICollection<Offer> Offers { get; set; } = new List<Offer>();

        public  ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<TripAttraction> TripAttractions { get; set; } = new List<TripAttraction>();
    }
}
