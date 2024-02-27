using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations;
public class PersonRepository : Repository<Person, int>, IPersonRepository
{
    public PersonRepository(DatabaseContext context) : base(context)
    {
    }

    /// <summary>
    /// Получить постраничный список
    /// </summary>
    /// <param name="page">номер страницы</param>
    /// <param name="itemsPerPage">объем страницы</param>
    /// <returns> Список курсов</returns>
    public async Task<List<Person>> GetPagedAsync(RepositoryPersonFilter filter, int page, int itemsPerPage)
    {
        var query = GetAll();
        if (!string.IsNullOrWhiteSpace(filter.Owner))
            query = query.Where(x => x.Creator == filter.Owner);
        return await query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();
    }
    
    
}
