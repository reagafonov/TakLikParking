using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Services.Abstractions;
using Services.Contracts;
using WebApi.Contracts.Dtos;
using WebApi.Models;

namespace WebApi.Controllers;

 [ApiController]
 [Route ("api/[controller]")]
public  class RoleController:CommonController<RoleApiDto,RoleDto,RoleModel,int>
{
    public RoleController(ICommonCrudService<RoleDto, int> crudService, IMapper mapper) : base(crudService, mapper)
    {
    }
}