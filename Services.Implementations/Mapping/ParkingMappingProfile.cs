using AutoMapper;
using Domain.Entities;
using Services.Contracts;

namespace Services.Implementations.Mapping;

public class ParkingMappingProfile:Profile
{
    public ParkingMappingProfile()
    {
        CreateMap<Parking, ParkingDTO>().ReverseMap();
    }
}