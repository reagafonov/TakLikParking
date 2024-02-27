using Domain.Entities;

namespace Services.Repositories.Abstractions;

public interface ICommonRepository<TEntity,TKey> : IRepository<TEntity, TKey> where TEntity:class,IEntity<TKey>
{
    Task<ICollection<TEntity>> GetPagedAsync(int page, int pageSize, CancellationToken token);
}
