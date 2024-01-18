using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts.Models;
using WebApi.Contracts.Dtos;
using WebApi.Contracts.Requests;
using WebApi.Contracts.Responses;

namespace WebApi.Controllers;
//[Authorize] // todo 
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class BookingController : ControllerBase
{
    private readonly ILogger<BookingController> _logger;
    private readonly IBookingService _service;
    private readonly IMapper _mapper;
    
    public BookingController(ILogger<BookingController> logger, IMapper mapper, IBookingService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    /// <summary>
    /// Получить записи о бронировании по Id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<GetBookingsApiResponse>> GetAsync([FromQuery]GetBookingsRequest request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<GetBookingsModel>(request);

        var result = await _service.GetBookingsAsync(model, cancellationToken);

        return Ok(_mapper.Map<GetBookingsApiResponse>(result));
    }

    /// <summary>
    /// Получить запись о бронировании по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookingApiDto>> GetByIdAsync([FromRoute]int id, CancellationToken cancellationToken)
    {
        var result = await _service.GetBookingIdAsync(id, cancellationToken);

        return Ok(_mapper.Map<BookingApiDto>(result));
    }

    /// <summary>
    /// Удалить запись о бронировании по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<BookingApiDto>> DeleteAsync([FromRoute]int id, CancellationToken cancellationToken)
    {
        await _service.DeleteBookingAsync(id, cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Создать запись о бронировании
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<int>> PostAsync([FromBody]PostBookingRequest request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<AddBookingModel>(request);
        
        var id = await _service.AddBookingAsync(model, cancellationToken);

        return Ok(id);
    }

    /// <summary>
    /// Обновить запись о бронировании
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{Id:int}")]
    public async Task<ActionResult<int>> PutAsync(PutBookingRequest request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<UpdateBookingModel>(request);
        
        await _service.UpdateBookingAsync(model, cancellationToken);

        return NoContent();
    }
}