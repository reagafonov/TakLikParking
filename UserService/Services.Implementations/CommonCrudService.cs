using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Repositories.Abstractions;

namespace Services.Implementations;

public class CommonCrudService<TDto,TEntity,TKey> : ICommonCrudService<TDto,TKey> where TDto:class where TEntity:class, IEntity<TKey>
{
    private readonly ILogger _logger;
    private readonly ICommonRepository<TEntity,TKey> _repository;
    private readonly IMapper _mapper;

    public CommonCrudService(ILogger<CommonCrudService<TDto,TEntity,TKey>> logger, ICommonRepository<TEntity,TKey> repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TKey> Create(TDto parkingDto, CancellationToken token)
    {
        var role = _mapper.Map<TEntity>(parkingDto);
        var result = _repository.Add(role);
        await _repository.SaveChangesAsync(token);
        return result.Id;
    }

    public async Task DeleteAsync(TKey id, CancellationToken token)
    {
        _repository.Delete(id);
        await _repository.SaveChangesAsync(token);
    }

    public async Task Update(TKey id, TDto dto, CancellationToken token)
    {
        var role = _mapper.Map<TDto, TEntity>(dto);
        role.Id = id;
        _repository.Update(role);
        await _repository.SaveChangesAsync(token);
    }

    public async Task<TDto> GetByID(TKey id, CancellationToken token)
    {
        var entity = await _repository.GetAsync(id, token);
        return _mapper.Map<TEntity, TDto>(entity);
    }

    public async Task<ICollection<TDto>> GetPaged(int page, int pageSize, CancellationToken token)
    {
        ICollection<TEntity> colection = await _repository.GetPagedAsync(page, pageSize, token);
        return _mapper.Map<ICollection<TEntity>, ICollection<TDto>>(colection);
    }

}
