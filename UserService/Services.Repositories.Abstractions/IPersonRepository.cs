using Domain.Entities;

namespace Services.Repositories.Abstractions;
public interface IPersonRepository : IRepository<Person, int>
{
    Task<List<Person>> GetPagedAsync(RepositoryPersonFilter filter, int page, int itemsPerPage);
}
