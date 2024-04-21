using System.ComponentModel.DataAnnotations;

namespace AF.Infrastructure.Entities
{
    public class Booking
    {
        [Key]
        public int BoekingId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
