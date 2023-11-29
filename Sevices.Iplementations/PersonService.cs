using AutoMapper;
using Services.Abstractions;
using Services.Contracts;
using Services.Repositories.Abstractions;

namespace Sevices.Iplementations;

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

    public Task<int> Create(PersonDto PersonDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PersonDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<PersonDto>> GetPaged(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, PersonDto PersonDto)
    {
        throw new NotImplementedException();
    }
}
