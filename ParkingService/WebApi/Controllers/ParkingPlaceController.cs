
using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Services.Contracts;

namespace WebApi.Controllers;

[ApiController]
[Route("api/ParkingPlace")]
public class ParkingPlaceController:ControllerBase
{
    private readonly IParkingService _service;
    private readonly IMapper _mapper;

    public ParkingPlaceController(IParkingService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
   
    [HttpGet("list/{page}/{itemPerPage}")]
    public async Task<IActionResult> GetPage([FromRoute]int page, [FromRoute]int itemPerPage, CancellationToken token)
    {
        var parkingDtos = await _service.GetPaged(page, itemPerPage, token);
        var result = _mapper.Map<List<ParkingResultModel>>(parkingDtos);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute]int id)
    {
        return Ok(_mapper.Map<ParkingResultModel>(await _service.GetByID(id)));
    }

    [HttpPost]
    public async Task<int> AddAsync([FromBody]ParkingModel model, CancellationToken token)
    {
        var dto = _mapper.Map<ParkingModel, ParkingDTO>(model);
        return await _service.Create(dto, token);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync([FromRoute]int id, [FromBody]ParkingModel model, CancellationToken token)
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
    
}