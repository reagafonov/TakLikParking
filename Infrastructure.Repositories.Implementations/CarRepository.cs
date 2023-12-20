using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations
{
    public class CarRepository : Repository<Car, int>, ICarRepository
    {

        public CarRepository(DatabaseContext context) : base(context) { }

        public async Task<ICollection<Car>> GetPagedAsync(int page, int pageSize, CancellationToken token)
        {
            return await GetAll().OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(token);
        }

    }
}
