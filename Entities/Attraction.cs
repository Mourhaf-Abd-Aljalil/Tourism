namespace ProjectTourism.Entities
{
    public class Attraction
    {
        public int AttractionId { get; set; }

        public string AttractionName { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public ICollection<TripAttraction> TripAttractions { get; set; } = new List<TripAttraction>();
    }
}
