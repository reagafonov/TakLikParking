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
        CreateMap<UserInfo,User>()
            .ForMember(x=>x.Roles,x=>x.MapFrom(y=>y.Roles)).ReverseMap();
        CreateMap<User, User>();
        CreateMap<User, UserDTO>()
            .ForMember(x => x.ID, x => x.MapFrom(y => y.Id))
            .ForMember(x=>x.Roles, x=>x.MapFrom(y=>(RolesEnum)y.Roles))
            .ReverseMap();
        CreateMap<UserDTO, UserResultModel>().ReverseMap();
        CreateMap<UserInfo, UserDTO>()
            .ForMember(x=>x.Roles,x=>x.Ignore())
            .ForMember(x=>x.ID, x=>x.MapFrom(y=>y.UserName)).ReverseMap();
    }
}