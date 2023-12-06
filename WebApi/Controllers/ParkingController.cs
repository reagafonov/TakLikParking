
using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Services.Contracts;

namespace WebApi.Controllers;

[ApiController]
[Route("api/Parking")]
public class ParkingController:ControllerBase
{
    private readonly IParkingService _service;
    private readonly IMapper _mapper;

    public ParkingController(IParkingService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
   
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute]int id)
    {
        return Ok(_mapper.Map<ParkingModel>(await _service.GetByID(id)));
    }

    [HttpPost]
    public async Task AddAsync(ParkingModel model, CancellationToken token)
    {
        var dto = _mapper.Map<ParkingModel, ParkingDTO>(model);
        await _service.Create(dto, default);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync(int id, ParkingModel model, CancellationToken token)
    {
        var dto = _mapper.Map<ParkingModel, ParkingDTO>(model); 
        await _service.Update(id, dto, token);
        return Ok();
    }

    [HttpDelete]
    public async Task Delete(int id, CancellationToken token)
    {
        await _service.Delete(id, token);
    }

    [HttpGet("/list/{page}/{itemPerPage}")]
    public async Task<IActionResult> GetPage(int page, int itemPerPage, CancellationToken token)
    {
        return Ok(await _service.GetPaged(page, itemPerPage, token));
    }
    
}