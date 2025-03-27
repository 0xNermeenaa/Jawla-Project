using AutoMapper;
using Infrastructure.DTO;
using Infrastructure.Models;
using Repository.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<CarDTO>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllAsync();
            return _mapper.Map<List<CarDTO>>(cars);
        }

        public async Task<CarDTO> GetCarByIdAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            return car != null ? _mapper.Map<CarDTO>(car) : null;
        }

        public async Task<List<CarDTO>> GetAvailableCarsAsync()
        {
            var cars = await _carRepository.GetAvailableCarsAsync();
            return _mapper.Map<List<CarDTO>>(cars);
        }

        public async Task<CarDTO> AddCarAsync(CarDTO carDTO)
        {
            var car = _mapper.Map<Car>(carDTO);
            car.Id = 0; // Ensure EF Core generates the ID
            var newCar = await _carRepository.AddAsync(car);
            return _mapper.Map<CarDTO>(newCar);
        }

        public async Task<bool> UpdateCarAsync(CarDTO carDTO)
        {

            if (!carDTO.Id.HasValue) return false; // التأكد من أن Id يحتوي على قيمة
            var car = await _carRepository.GetByIdAsync(carDTO.Id.Value);

            if (car == null) return false;

            _mapper.Map(carDTO, car);
            await _carRepository.UpdateAsync(car);
            return true;
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null) return false;

            await _carRepository.DeleteAsync(car);
            return true;
        }








        //




        public async Task<List<Car>> GetCarsByIdsAsync(List<int> carIds)
        {
            return await _carRepository.GetCarsByIdsAsync(carIds);
        }


    }
}
