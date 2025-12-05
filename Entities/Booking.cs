namespace ProjectTourism.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int? UserId { get; set; }

        public int? TripId { get; set; }

        public DateTime? BookingDate { get; set; }

        public decimal? CostBooking { get; set; }

        public bool? Status { get; set; }

        public  ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public  Trip? Trip { get; set; }

        public  User? User { get; set; }
    }
}
