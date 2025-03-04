using AutoMapper;
using Infrastructure.DTO;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            {
                CreateMap<Trip, AllTripsDTO>()
                   .ForMember(dest => dest.Main_Image, opt => opt.MapFrom(src => src.Images.FirstOrDefault().main_image)).ReverseMap();

                //

                CreateMap<Trip, TripDetailsDTO>().ReverseMap();


            }
        }

    }
}
