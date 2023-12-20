using AutoMapper;
using Domain.Entities;
using Services.Abstractions;
using Services.Contracts;
using Services.Repositories.Abstractions;

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
            var car = await _carRepository.GetAsync(id);
            return _mapper.Map<Car, CarDto>(car);
        }

        public async Task<int> CreateCar(CarDto carDto, CancellationToken token)
        {
            var car = _mapper.Map<Car>(carDto);
            var result = _carRepository.Add(car);
            await _carRepository.SaveChangesAsync(token);
            return result.Id;

        }
        public async Task DeleteCar(int id, CancellationToken token)
        {
            _carRepository.Delete(id);
            await _carRepository.SaveChangesAsync(token);
        }

        public async Task UpdateCar(int id, CarDto carDto, CancellationToken token)
        {
            var car = _mapper.Map<CarDto, Car>(carDto);
            car.Id = id;
            _carRepository.Update(car);
            await _carRepository.SaveChangesAsync(token);
        }

        public async Task<ICollection<CarDto>> GetPaged(int page, int pageSize, CancellationToken token)
        {
            ICollection<Car> carCollection = await _carRepository.GetPagedAsync(page, pageSize, token);

            return _mapper.Map<ICollection<Car>, ICollection<CarDto>>(carCollection);
        }

    }
}
