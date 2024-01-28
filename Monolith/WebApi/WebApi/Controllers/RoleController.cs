using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _service;
    private readonly IMapper _mapper;

    public RoleController(IRoleService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("list/{page}/{itemPerPage}")]
    public async Task<IActionResult> GetPage([FromRoute] int page, [FromRoute] int itemPerPage, CancellationToken token)
    {
        var rolesDto = await _service.GetPaged(page, itemPerPage, token);
        var result = _mapper.Map<List<RoleResultModel>>(rolesDto);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
    {
        return Ok(_mapper.Map<RoleResultModel>(await _service.GetByID(id)));
    }

    [HttpPost]
    public async Task<int> AddAsync([FromBody] RoleModel model, CancellationToken token)
    {
        var dto = _mapper.Map<RoleModel, RoleDto>(model);
        return await _service.Create(dto, token);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync([FromRoute] int id, [FromBody] RoleModel model, CancellationToken token)
    {
        var dto = _mapper.Map<RoleModel, RoleDto>(model);
        await _service.Update(id, dto, token);
        return Ok();
    }

    [HttpDelete]
    public async Task Delete(int id, CancellationToken token)
    {
        await _service.Delete(id, token);
    }
}
