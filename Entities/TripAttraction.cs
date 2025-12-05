namespace ProjectTourism.Entities
{
    public class TripAttraction
    {
        public int TripAttractionId { get; set; }

        public int AttractionId { get; set; }

        public int TripId { get; set; }

        public  Attraction? Attraction { get; set; }

        public  Trip? Trip { get; set; }
    }
}
