using Domain.Entities;

namespace Services.Repositories.Abstractions;

public interface IParkingRepository:IRepository<Parking,int>
{
    Task<ICollection<Parking>> GetPagedAsync(int page, int pageSize, CancellationToken token);
}