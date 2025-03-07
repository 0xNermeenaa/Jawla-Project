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

using CloudinaryDotNet.Actions;



namespace Repository.Service
{
    using Infrastructure.DTO.TripDTO;

    public class TripService : ITripService
    {
        private readonly ICloudinaryService _cloudinaryService;

       

        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public TripService(ITripRepository tripRepository, IMapper mapper ,ICloudinaryService cloudinaryService)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;

            _cloudinaryService = cloudinaryService;
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



        //----------------------------------------------------

        public async Task<Trip> AddTripِAsync(AddUpdateTripDTO trip)
        {

            var tripModel = _mapper.Map<Trip>(trip);


            if (trip.Main_image == null|| trip.Images ==null)
            {
                throw new ArgumentException("Main_image and Images cannot be null.");
            }

            var M_image = await _cloudinaryService.UploadImageAsync(trip.Main_image);
            tripModel.Images.main_image = M_image;

            var images = await _cloudinaryService.UploadImageAsync(trip.Images);
            tripModel.Images.Images = images;



            var addtrip = await _tripRepository.AddAsync(tripModel);


            var Trip = _mapper.Map<Trip>(addtrip);
            return Trip;
        }
         
        //---------------------------------

        public async Task<bool> DeleteTripAsync(int id) 
        {

            var trip = await _tripRepository.GetByIdAsync(id);

            if (trip == null) return false;

            
            await _cloudinaryService.DeleteImageAsync(trip.Images.main_image);
            await _cloudinaryService.DeleteImageAsync(trip.Images.Images);

            await _tripRepository.DeleteAsync(trip);
            return true;
        }


        //-------------------------------------------


        public async Task<bool> UpdateTripAsync(AddUpdateTripDTO trip)
        {

            if (trip == null) return false;

            var tripModel = _mapper.Map<Trip>(trip);


            if (tripModel == null) return false;

            var existingTrip = await _tripRepository.GetByIdAsync(trip.Id);
            if (existingTrip == null) return false;


            if (trip.Main_image == null || trip.Images == null)
            {
                throw new ArgumentException("Main_image and Images cannot be null.");
            }

            var M_image = await _cloudinaryService.UploadImageAsync(trip.Main_image);
            tripModel.Images.main_image = M_image;

            var images = await _cloudinaryService.UploadImageAsync(trip.Images);
            tripModel.Images.Images = images;

            _tripRepository.UpdateAsync(tripModel);
            
            
            return true;


        }




    }

}
