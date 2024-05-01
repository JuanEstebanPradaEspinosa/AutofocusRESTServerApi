using AF.Application.DTO_s.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Application.DTO_s.Input
{
    public class TenantRESToutputDTO : UserRestnormalDTO
    {
        public string? StudioName { get; set; } //for tenant
        public List<BookingRESTnormalDTO> Bookings { get; set; }

    }
}
