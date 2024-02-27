using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations;
public class CommonRepository<TEntity,TKey> : Repository<TEntity, TKey>, ICommonRepository<TEntity,TKey> where TEntity:class,IEntity<TKey> 
{
    public CommonRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<ICollection<TEntity>> GetPagedAsync(int page, int pageSize, CancellationToken token)
    {
        return await GetAll().OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(token);
    }
}
