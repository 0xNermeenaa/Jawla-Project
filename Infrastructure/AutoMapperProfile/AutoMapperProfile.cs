using AutoMapper;
using Infrastructure.DTO.TripDTO;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AutoMapperProfile
{
    using Infrastructure.DTO.TripDTO;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            {
                CreateMap<Trip, AllTripsDTO>()
                   .ForMember(dest => dest.Main_Image, opt => opt.MapFrom(src => src.Images.main_image)).ReverseMap();

                //

                CreateMap<Trip, TripDetailsDTO>().ReverseMap();
                CreateMap<CarDTO, Car>().ReverseMap();
                CreateMap<DriverDTO, Driver>().ReverseMap();


                //



                CreateMap<AddUpdateTripDTO, Trip>()
                 .ForMember(dest => dest.Cars, opt => opt.MapFrom((src, dest, _, context) =>
                  {
                   var dbContext = context.Items["DbContext"] as AppContext;
                   return dbContext.Cars.Where(car => src.CarIds.Contains(car.Id)).ToList();
                    }))
                  .ForMember(dest => dest.Tourguides, opt => opt.MapFrom((src, dest, _, context) =>
                  {
                    var dbContext = context.Items["DbContext"] as AppContext;
                    return dbContext.Tourguides.Where(tg => src.TourguideIds.Contains(tg.Id)).ToList();
                   })).ReverseMap();


            }
        }

    }
}
