using AutoMapper;
using Services.Contracts;
using WebApi.Models;

namespace WebApi.Mapping;

public class PersonMappingProfile : Profile
{
    public PersonMappingProfile() 
    {
        CreateMap<PersonDto, PersonModel>();
        CreateMap<PersonModel, PersonDto>();
    }
}
