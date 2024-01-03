using Services.Contracts;

namespace Services.Abstractions
{
    public interface ICarService
    {
        Task<ICollection<CarDto>> GetPaged(int page, int pageSize, CancellationToken token);

        Task<CarDto> GetCarById(int id);

        Task<int> CreateCar(CarDto carDto, CancellationToken token);

        Task UpdateCar(int id, CarDto carDto, CancellationToken token);

        Task DeleteCar(int id, CancellationToken token);
    }
}
