using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts;
using Services.Repositories.Abstractions;

namespace Services.Implementations;

public class RoleService : IRoleService
{
    private readonly ILogger<RoleService> _logger;
    private readonly IRoleRepository _repository;
    private readonly IMapper _mapper;

    public RoleService(ILogger<RoleService> logger, IRoleRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Create(RoleDto parkingDto, CancellationToken token)
    {
        var role = _mapper.Map<Role>(parkingDto);
        var result = _repository.Add(role);
        await _repository.SaveChangesAsync(token);
        return result.Id;
    }

    public async Task Delete(int id, CancellationToken token)
    {
        _repository.Delete(id);
        await _repository.SaveChangesAsync(token);
    }

    public async Task Update(int id, RoleDto dto, CancellationToken token)
    {
        var role = _mapper.Map<RoleDto, Role>(dto);
        role.Id = id;
        _repository.Update(role);
        await _repository.SaveChangesAsync(token);
    }

    public async Task<RoleDto> GetByID(int id)
    {
        var entity = await _repository.GetAsync(id);
        return _mapper.Map<Role, RoleDto>(entity);
    }

    public async Task<ICollection<RoleDto>> GetPaged(int page, int pageSize, CancellationToken token)
    {
        ICollection<Role> colection = await _repository.GetPagedAsync(page, pageSize, token);
        return _mapper.Map<ICollection<Role>, ICollection<RoleDto>>(colection);
    }

}
