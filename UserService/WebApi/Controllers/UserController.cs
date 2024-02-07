using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts;
using WebApi.Contracts.Dtos;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]


public class UserController:ControllerBase
{
    private readonly ICommonCrudService<UserDTO, int> _crudService;
    private readonly IMapper _mapper;
    
    public UserController(ICommonCrudService<UserDTO, int> crudService, IMapper mapper)
    {
        _crudService = crudService;
        _mapper = mapper;
    }
    
    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetByIdAsync([FromRoute] int id, CancellationToken token)
    {
        var businessDto = await _crudService.GetByID(id, token);
        var roleApiDto = _mapper.Map<UserResultModel>(businessDto);
        return Ok(roleApiDto);
    }


    [HttpGet("items-per-page/{itemPerPage:int}/page/{page:int}")]
    public virtual async Task<IActionResult> GetPagesAsync([FromRoute] int page, [FromRoute] int itemPerPage,
        CancellationToken token)
    {
        var pagedData = await _crudService.GetPaged(page, itemPerPage, token);
        var mapped = _mapper.Map<List<UserResultModel>>(pagedData);
        return Ok(mapped);
    }
    
    
    [HttpPost]
    public virtual async Task<int> AddAsync([FromBody]UserModel model, CancellationToken token)
    {
        var dto = _mapper.Map<UserModel, UserDTO>(model);
        return await _crudService.Create(dto, token);
    }

    [HttpPut("{id}")]
    public virtual async Task<IActionResult> EditAsync([FromRoute]int id, [FromBody]UserModel model, CancellationToken token)
    {
        var dto = _mapper.Map<UserModel, UserDTO>(model); 
        await _crudService.Update(id, dto, token);
        return Ok();
    }

    [HttpDelete]
    public async Task DeleteAsync(int id, CancellationToken token)
    {
        await _crudService.DeleteAsync(id, token);
    }
}