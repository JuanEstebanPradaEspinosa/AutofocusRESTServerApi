using AF.Application.DTO_s.Output;
using AF.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Application.DTO_s.Input
{
    public class LesserRESToutputDTO : UserRestnormalDTO
    {
        public string? BtwNr { get; set; }
        public List<CarRESToutputDTO> Cars { get; set; } = new();
    }
}
