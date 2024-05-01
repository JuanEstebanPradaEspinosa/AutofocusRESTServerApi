using AF.Application.DTO_s;
using AF.Application.DTO_s.Input;
using AF.Application.DTO_s.Output;
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
            
            //Car Mappers
            CreateMap<Car, CarModel>().ReverseMap();
            CreateMap<CarModel, CarRESToutputDTO>();
            CreateMap<CarRESTinputDTO, CarModel>();

            //Booking Mappers
            CreateMap<BookingModel, BookingRESTnormalDTO>().ReverseMap();
            CreateMap<Booking, BookingModel>().ReverseMap();

            //User Mapper
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<UserModel, UserRestnormalDTO>();

            CreateMap<Tenant, TenantModel>().ReverseMap();
            CreateMap<TenantModel, TenantRESToutputDTO>();

            CreateMap<Lessor, LessorModel>().ReverseMap();
            CreateMap<LessorModel, LesserRESToutputDTO>();
        }
    }
}
