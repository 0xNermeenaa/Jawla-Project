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

        private readonly ITourguideRepository _TourguideRepository;
        private readonly ICarRepository _CarRepository;

        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public TripService(ITripRepository tripRepository, IMapper mapper ,ICloudinaryService cloudinaryService,
                           ITourguideRepository tourguideRepository, ICarRepository carRepository
                                                                                                               )
        {

            _CarRepository = carRepository;
            _TourguideRepository = tourguideRepository;

            _tripRepository = tripRepository;
            _mapper = mapper;

            _cloudinaryService = cloudinaryService;
        }

        //-------------------------------------------------------

        public async Task<List<AllTripsDTO>> GetAllTripsAsync()
        {
            var trips = await _tripRepository.GetAlltripAsync();


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

            
            if (trip.CarIds != null && trip.CarIds.Any())
            {
                // استخدام Repository لجلب السيارات
                var cars = await _CarRepository.GetCarsByIdsAsync(trip.CarIds);

                if (cars.Count != trip.CarIds.Count)
                {
                    throw new ArgumentException("Some Car IDs are invalid or not found.");
                }

                tripModel.Cars = cars; // ربط السيارات بالرحلة
            }

            // معالجة المرشدين السياحيين
            if (trip.TourguideIds != null && trip.TourguideIds.Any())
            {
                // استخدام Repository لجلب المرشدين السياحيين
                var tourguides = await _TourguideRepository.GetTourguidesByIdsAsync(trip.TourguideIds);

                if (tourguides.Count != trip.TourguideIds.Count)
                {
                    throw new ArgumentException("Some Tourguide IDs are invalid or not found.");
                }

                tripModel.Tourguides = tourguides; // ربط المرشدين السياحيين بالرحلة
            }
            
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

            var existingTrip = await _tripRepository.GetByIdAsync((int)trip.Id);
            if (existingTrip == null) return false;

            if (trip.Main_image == null || trip.Images == null)
            {
                throw new ArgumentException("Main_image and Images cannot be null.");
            }

            // تحديث الحقول الموجودة مباشرة
            _mapper.Map(trip, existingTrip); // تحديث القيم في الكيان الموجود

            // تحميل الصور
            var M_image = await _cloudinaryService.UploadImageAsync(trip.Main_image);
            existingTrip.Images.main_image = M_image;

            var images = await _cloudinaryService.UploadImageAsync(trip.Images);
            existingTrip.Images.Images = images;

            // التحديث النهائي
            await _tripRepository.UpdateAsync(existingTrip);

            return true;
        }


        //



        public async Task<TripAdminDTO> GetTripAdmin(int id)
        {
           var ATrip=await _tripRepository.GetTripAdmin(id);

           return _mapper.Map<TripAdminDTO>(ATrip);

        }



        //

        public async Task<List<Reservation>> GetAllReservationsAsync(int tripId)
        {
            var trip = await _tripRepository.GetTripWithReservationsAsync(tripId);

            if (trip == null)
            {
                throw new Exception("Trip not found");
            }

            return trip.Reservations.ToList();
        }

        //


        public async Task<bool> UpdateTripStateAsync(int tripId, string newState)
        {
            // 1. Validate the new state
            var validStates = new List<string> { "Finished", "Cancelled", "Active" }; // Or define these as constants/enum
            if (!validStates.Contains(newState))
            {
                // Option 1: Throw exception
                throw new ArgumentException($"Invalid state provided: {newState}. Valid states are: {string.Join(", ", validStates)}");
                // Option 2: Return false (less informative, but avoids exceptions if preferred)
                // return false;
            }

            // 2. Retrieve the trip
            var existingTrip = await _tripRepository.GetByIdAsync(tripId);

            // 3. Handle not found
            if (existingTrip == null)
            {
                return false; // Trip not found
            }

            // 4. Update the state property
            existingTrip.Stste = newState;

            // 5. Persist changes using the repository
            await _tripRepository.UpdateAsync(existingTrip); // Assumes UpdateAsync saves changes

            // 6. Return success
            return true;
        }






        public async Task<List<reservationDTO>> GetTripResevations(int tripid)
        {

           var res =await _tripRepository.GetTripReservationsAsync(tripid);
           var r= _mapper.Map<List<reservationDTO>>(res);
            return r;

           

        }


    }

}
