using AutoMapper;
using Domain.Entities;
using Services.Contracts;
using WebApi.Models;

namespace WebApi.Mapping;

public class RoleMappingProfile : Profile
{
    public RoleMappingProfile() 
    {
        CreateMap<RoleDto, RoleModel>().ReverseMap();
        CreateMap<RoleDto, Role>().ReverseMap();
        CreateMap<RoleDto, RoleResultModel>().ReverseMap();
    }
}
