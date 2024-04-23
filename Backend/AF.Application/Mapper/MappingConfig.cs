using AF.Application.Models;
using AF.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Application.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Domain.Entities.Car, Models.CarModel>().ReverseMap();
        }
    }
}
