using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.DL.Entities
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Bedrijfsnaam { get; set; }
        public string ContactPersoon { get; set; }
        public string BtwNummer {  get; set; }
        public string Adress { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
