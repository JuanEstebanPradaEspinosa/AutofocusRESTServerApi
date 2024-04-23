using System.ComponentModel.DataAnnotations;

namespace AF.Application.Models
{
    public class Booking
    {
        public Booking(DateTime startDatum, DateTime eindDatum)
        {
            StartDatum = startDatum;
            EindDatum = eindDatum;
        }

        public Booking(int id, DateTime startDatum, DateTime eindDatum)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
        }

        public int Id { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
