using AutoMapper;
using Domain.Entities;
using Services.Contracts;
using WebApi.Contracts.Dtos;
using WebApi.Models;

namespace WebApi.Mapping;

public class UserMappingProfile:Profile
{
    public UserMappingProfile()
    {
        CreateMap<User,UserDTO>().ReverseMap();
        CreateMap<UserDTO, UserResultModel>().ReverseMap();
        CreateMap<UserModel, UserDTO>().ReverseMap();
    }
}