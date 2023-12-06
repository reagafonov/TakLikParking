using AutoMapper;
using Domain.Entities;
using Services.Abstractions;
using Services.Contracts;
using Services.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public CarService(
            IMapper mapper,
            ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

      
        public async Task<CarDto> GetCarById(int id)
        {
            var cars = await _carRepository.GetCars();
            return _mapper.Map<CarDto>(cars.Select(c => c.Id == id));
        }

        public async Task<int> CreateCar(CarDto carDto)
        {
            var car = _mapper.Map<CarDto, Car>(carDto);
            return await _carRepository.AddCar(car);
        }
        public async Task<bool> DeleteCar(int id)
        {
            return await _carRepository.DeleteCar(id);
        }

        public async Task UpdateCar(int id, CarDto carDto)
        {
            var car = _mapper.Map<CarDto, Car>(carDto);
            car.Id = id;
            await _carRepository.UpdateCar(car);
        }




    }
}
