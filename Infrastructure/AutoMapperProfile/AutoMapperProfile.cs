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
                CreateMap<Trip, TripDetailsDTO>()
                .ForMember(dest => dest.Main_image, opt => opt.MapFrom(src => src.Images.main_image))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Images)).ReverseMap();
                //

               // CreateMap<TripDetailsDTO, Trip>().ReverseMap();
                CreateMap<CarDTO, Car>().ReverseMap();
                CreateMap<DriverDTO, Driver>().ReverseMap();
                CreateMap<TourguideDTO, Tourguide>().ReverseMap();

                //



                CreateMap<AddUpdateTripDTO, Trip>()
    .ForMember(dest => dest.Images, opt => opt.Ignore());
    //.ForMember(dest => dest.Main_image, opt => opt.Ignore());




            }
        }

    }
}
