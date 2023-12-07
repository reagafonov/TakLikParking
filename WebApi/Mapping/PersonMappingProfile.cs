using AutoMapper;
using Domain.Entities;
using Services.Contracts;
using WebApi.Models;

namespace WebApi.Mapping;

public class PersonMappingProfile : Profile
{
    public PersonMappingProfile() 
    {
        CreateMap<PersonDto, PersonModel>().ReverseMap();
        CreateMap<PersonDto, Person>().ReverseMap();
        CreateMap<PersonDto, PersonResultModel>().ReverseMap();
    }
}
