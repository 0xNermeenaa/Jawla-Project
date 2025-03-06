using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.DTO;
using Infrastructure.Models;
using Repository.IRepositories;

namespace Repository.Service
{
   
        public class DriverService : IDriverService
        {
            private readonly IDriverRepository _driverRepository;
            private readonly IMapper _mapper;

            public DriverService(IDriverRepository driverRepository, IMapper mapper)
            {
                _driverRepository = driverRepository;
                _mapper = mapper;
            }

            public async Task<List<DriverDTO>> GetAllDriversAsync()
            {
                var drivers = await _driverRepository.GetAllAsync();
                return _mapper.Map<List<DriverDTO>>(drivers);
            }

            public async Task<DriverDTO> GetDriverByIdAsync(int id)
            {
                var driver = await _driverRepository.GetByIdAsync(id);
                return _mapper.Map<DriverDTO>(driver);
            }

            public async Task<List<DriverDTO>> GetDriversByCarIdAsync(int carId)
            {
                var drivers = await _driverRepository.GetDriversByCarIdAsync(carId);
                return _mapper.Map<List<DriverDTO>>(drivers);
            }

        public async Task<DriverDTO> AddDriverAsync(DriverDTO driverDTO)
        {
            var driver = _mapper.Map<Driver>(driverDTO);
            driver.Id = 0; // السماح لقاعدة البيانات بإنشاء ID تلقائيًا
            var newDriver = await _driverRepository.AddAsync(driver);
            return _mapper.Map<DriverDTO>(newDriver);
        }


        public async Task<bool> UpdateDriverAsync(DriverDTO driverDTO)
            {
            //var driver = await _driverRepository.GetByIdAsync(driverDTO.Id);
            if (driverDTO.Id == null)
                return false; // أو قم بإرجاع استجابة مناسبة

            var driver = await _driverRepository.GetByIdAsync(driverDTO.Id.Value);

            if (driver == null) return false;

                _mapper.Map(driverDTO, driver);
                await _driverRepository.UpdateAsync(driver);
                return true;
            }

            public async Task<bool> DeleteDriverAsync(int id)
            {
                var driver = await _driverRepository.GetByIdAsync(id);
                if (driver == null) return false;

                await _driverRepository.DeleteAsync(driver);
                return true;
            }
        }
    }

