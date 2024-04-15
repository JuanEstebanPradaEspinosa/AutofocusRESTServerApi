using System.ComponentModel.DataAnnotations;

namespace AF.Domain.Entities {
    public class Booking {
        [Key]
        public int BoekingId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
