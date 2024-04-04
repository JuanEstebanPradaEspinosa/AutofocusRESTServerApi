namespace AF.DL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public bool Availability { get; set; }
        public Owner Owner { get; set; } //has a owner
        public List<Booking> Bookings { get; set; } = null; //can have bookings
    }
}
