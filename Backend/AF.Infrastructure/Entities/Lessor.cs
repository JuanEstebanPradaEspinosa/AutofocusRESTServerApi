namespace AF.Infrastructure.Entities
{
    public class Lessor : User 
    { 
        public User? User { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
