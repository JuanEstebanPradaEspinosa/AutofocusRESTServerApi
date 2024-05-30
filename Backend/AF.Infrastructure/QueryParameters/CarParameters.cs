using AF.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Infrastructure.QueryParameters
{
    public class CarParameters : QueryStringParameters
    {
        //Ordering
        public CarParameters()
        {
            OrderBy = "Model";
        }

        //filters toevoegen om dan bij de repository te gebruiken welke waarde dat je nodig hebt
        //Filter bij de controllers + repository

        //searching method toevoegen
        public string? Brand { get; set; }
    }
}
