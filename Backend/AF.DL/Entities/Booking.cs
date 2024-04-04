using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.DL.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool HasOwnerSigned { get; set; } = false;
        public bool HasTenantSigned { get; set; } = false;  
        public string AssignedAddress { get; set; }
        public Car Car { get; set; }
        public Tenant Tenant { get; set; }

    }
}
