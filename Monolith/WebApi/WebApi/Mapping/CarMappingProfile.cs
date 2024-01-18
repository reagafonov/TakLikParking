using AutoMapper;
using Domain.Entities;
using Services.Contracts;
using WebApi.Models;

namespace WebApi.Mapping;

public class CarMappingProfile : Profile
{
    public CarMappingProfile()
    {
        CreateMap<Car, CarDto>()
            .ForMember(x=>x.Id,x=>x.MapFrom(y=>y.Id))
            .ReverseMap();
        CreateMap<CarModel, CarDto>();

        CreateMap<CarDto, CarResultModel>();
    }
}
