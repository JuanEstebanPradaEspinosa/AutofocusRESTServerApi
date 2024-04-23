using System.ComponentModel.DataAnnotations;

namespace AF.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
