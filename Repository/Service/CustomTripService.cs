using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repository;
using Repository.IRepositories;
using AutoMapper;
using Infrastructure.DTO;
using Infrastructure.Models;
using Infrastructure.DTO.TripDTO;
namespace Repository.Service
{

    public interface ICustomTripService {
        Task<bool> RequestCustomTrip(CustomTripDTO customTrip);
        Task<string> ResponseCustomTrip(AdminCustomTripDTO customtrip);
        Task<List<AllCustomTripDTO>> AllCustomTrip();
    }

    //----------------------------
    public class CustomTripService : ICustomTripService
    {
        private readonly ICustomTripRepository _customTriprepository;
        private readonly IMapper _Mapper;

        public CustomTripService(ICustomTripRepository customTripRepository,IMapper mapper)
        {
            _Mapper = mapper;
            _customTriprepository = customTripRepository;
        }
        //-------------------------------------------



        public async Task<bool> RequestCustomTrip(CustomTripDTO customTrip)
        {
            if (customTrip == null || customTrip.StartTime >= customTrip.EndTime)
                return false;

            try
            {
                var tripEntity = _Mapper.Map<CustomTrip>(customTrip);
                tripEntity.State = "Wait";
                await _customTriprepository.AddAsync(tripEntity);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<string> ResponseCustomTrip(AdminCustomTripDTO customtrip)
        {
            if (customtrip == null) return "Invalid input data.";

            var CTrip = await _customTriprepository.GetByIdAsync(customtrip.Id);

            if (CTrip == null)
            {
                return "Custom trip not found.";
            }

            if (customtrip.Ok == false)
            {
                CTrip.State = "Reject";
                await _customTriprepository.UpdateAsync(CTrip);
                return "Custom trip rejected.";
            }

            if (customtrip.Ok == true)
            {
                CTrip.State = "Accept";
                await _customTriprepository.UpdateAsync(CTrip);
                return "Custom trip accepted.";
            }

            return "Unexpected response.";
        }


        //




        public async Task<List<AllCustomTripDTO>> AllCustomTrip()
        { 

            var all=await _customTriprepository.GetAllAsync();

            var AllTrips = _Mapper.Map<List<AllCustomTripDTO>>(all);
            return AllTrips;

        }



        

    }

}

