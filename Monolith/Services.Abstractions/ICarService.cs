using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ICarService
    {

        Task<CarDto> GetCarById(int id);

        Task<int> CreateCar(CarDto carDto);

        Task UpdateCar(int id, CarDto carDto);

        Task<bool> DeleteCar(int id);
    }
}
