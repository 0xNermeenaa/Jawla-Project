using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;
using Infrastructure.Models;


using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;

namespace Repository.Service
{
    public class TripService : ITripService
    {
        
        
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public TripService(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        //-------------------------------------------------------

        public async Task<List<AllTripsDTO>> GetAllTripsAsync()
        {
            var trips = await _tripRepository.GetAllAsync();


            var AllTrips = _mapper.Map<List<AllTripsDTO>>(trips);
            return AllTrips;
        }


        //---------------------------------------

        public async Task<TripDetailsDTO> GetTripDetailsAsync(int id)
        {
            var trip = await _tripRepository.GetByIdAsync(id);


            var Trip = _mapper.Map<TripDetailsDTO>(trip);
            return Trip;
        }






        public int hh()
        {

            return _tripRepository.hg();


        }



    }

}
