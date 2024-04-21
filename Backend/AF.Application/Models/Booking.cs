using System.ComponentModel.DataAnnotations;

namespace AF.Application.Models
{
    public class Booking
    {
        [Key]
        public int BoekingId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
