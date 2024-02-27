using AutoMapper;
using Domain.Entities;
using Services.Abstractions;
using Services.Contracts;
using Services.Contracts.Filters;
using Services.Repositories.Abstractions;

namespace Services.Implementations;

public class PersonService : IPersonService
{
    private readonly IMapper _mapper;
    private readonly IPersonRepository _personRepository;

    public PersonService(
        IMapper mapper,
        IPersonRepository courseRepository)
    {
        _mapper = mapper;
        _personRepository = courseRepository;
    }

    public async Task<int> Create(PersonDto personDto)
    {
        var entity = _mapper.Map<PersonDto, Person>(personDto);
        var res = await _personRepository.AddAsync(entity);
        await _personRepository.SaveChangesAsync();
        return res.Id;
    }

    public async Task<bool> Delete(int id, CancellationToken token)
    {
        var person = await _personRepository.GetAsync(id, token);
        var res = _personRepository.Delete(person, token);
        await _personRepository.SaveChangesAsync(token);
        return res;
    }

    public async Task<PersonDto> GetById(int id, CancellationToken token)
    {
        var person = await _personRepository.GetAsync(id, token);
        return _mapper.Map<PersonDto>(person);
    }

    public async Task<ICollection<PersonDto>> GetPaged(PersonFilter filter,int page, int pageSize)
    {
        var repoFilter = _mapper.Map<RepositoryPersonFilter>(filter);
        var entities = await _personRepository.GetPagedAsync(repoFilter, page, pageSize);
        return _mapper.Map<ICollection<Person>, ICollection<PersonDto>>(entities);
    }

    public async Task Update(int id, PersonDto personDto)
    {
        var entity = _mapper.Map<PersonDto, Person>(personDto);
        entity.Id = id;
        _personRepository.Update(entity);
        await _personRepository.SaveChangesAsync();
    }
}
