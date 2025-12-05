namespace ProjectTourism.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public bool UserType { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
