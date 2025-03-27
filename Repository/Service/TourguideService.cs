using AutoMapper;
using Infrastructure.DTO;
using Infrastructure.Models;
using Repository.IRepositories;

namespace Repository.Service
{
    public class TourguideService : ITourguideService
    {
        private readonly ITourguideRepository _tourguideRepository;
        private readonly IMapper _mapper;

        public TourguideService(ITourguideRepository tourguideRepository, IMapper mapper)
        {
            _tourguideRepository = tourguideRepository;
            _mapper = mapper;
        }

        public async Task<List<TourguideDTO>> GetAllTourguidesAsync()
        {
            var tourguides = await _tourguideRepository.GetAllAsync();
            return _mapper.Map<List<TourguideDTO>>(tourguides);
        }

        public async Task<TourguideDTO> GetTourguideByIdAsync(int id)
        {
            var tourguide = await _tourguideRepository.GetByIdAsync(id);
            return _mapper.Map<TourguideDTO>(tourguide);
        }

        public async Task<TourguideDTO> AddTourguideAsync(TourguideDTO tourguideDTO)
        {
            var tourguide = _mapper.Map<Tourguide>(tourguideDTO);
            await _tourguideRepository.AddAsync(tourguide);
            return _mapper.Map<TourguideDTO>(tourguide);
        }

        public async Task<bool> UpdateTourguideAsync(TourguideDTO tourguideDTO)
        {
            if (tourguideDTO.Id == null) return false; // or throw an exception

            var existingTourguide = await _tourguideRepository.GetByIdAsync(tourguideDTO.Id.Value);
            if (existingTourguide == null) return false;

            // Map the DTO into the existing entity
            _mapper.Map(tourguideDTO, existingTourguide);

            var UpdateTourguide = await
            _tourguideRepository.UpdateAsync(existingTourguide);
            return UpdateTourguide != null;
        }

        public async Task<bool> DeleteTourguideAsync(int id)
        {
            // If you need to check existence:
            var existingTourguide = await _tourguideRepository.GetByIdAsync(id);
            if (existingTourguide == null) return false;

            // The repository expects an int, so pass 'id'
            return await _tourguideRepository.DeleteAsync(id);
        }



        //







    }
}
