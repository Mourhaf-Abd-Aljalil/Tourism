namespace ProjectTourism.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal DiscountValue { get; set; }

        public int TripId { get; set; }

        public  Trip? Trip { get; set; }
    }
}
