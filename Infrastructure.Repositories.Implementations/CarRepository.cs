using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public class CarRepository : Repository<Car, int>, ICarRepository
    {

        public CarRepository(DbContext context) : base(context) { }


        public async Task<IEnumerable<Car>> GetCars()
        {
            var query = GetAll();
            return await query.ToListAsync();
        }

        public async Task<int> AddCar(Car car)
        { 
            var carId = AddAsync(car).Id;
            SaveChanges();
            return carId;
        }

        public async Task<bool> DeleteCar(int id)
        {
            var car = await GetAsync(id);
            var res = Delete(car);
            await SaveChangesAsync();
            return res;
        }

        public async Task UpdateCar(Car car)
        {
            Update(car);
            await SaveChangesAsync();
        }

    }
}
