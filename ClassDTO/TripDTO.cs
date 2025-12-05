namespace ProjectTourism.ClassDTO
{
    public class TripDTO
    {
        public int TripId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? Price { get; set; }
    }
}
