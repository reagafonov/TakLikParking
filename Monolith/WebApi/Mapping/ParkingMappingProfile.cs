using AutoMapper;
using Domain.Entities;
using Services.Contracts;
using WebApi.Models;

namespace WebApi.Mapping;

public class ParkingMappingProfile:Profile
{
    public ParkingMappingProfile()
    {
        CreateMap<Parking, ParkingDTO>()
            .ForMember(x=>x.Id,x=>x.MapFrom(y=>y.Id))
            .ReverseMap();
        CreateMap<ParkingModel, ParkingDTO>()
            .ForMember(x => x.Address, x => x.MapFrom(y => y.GetAddress()));

        CreateMap<ParkingDTO, ParkingResultModel>()
            .ForMember(x=>x.Id,x=>x.MapFrom(y=>y.Id));
    }
}