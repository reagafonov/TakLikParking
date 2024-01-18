using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Car")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _service;
        private readonly IMapper _mapper;

        public CarController(ICarService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("list/{page}/{itemPerPage}")]
        public async Task<IActionResult> GetPage([FromRoute] int page, [FromRoute] int itemPerPage, CancellationToken token)
        {
            var carDtos = await _service.GetPaged(page, itemPerPage, token);
            var result = _mapper.Map<List<CarResultModel>>(carDtos);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            return Ok(_mapper.Map<CarResultModel>(await _service.GetCarById(id)));
        }

        [HttpPost]
        public async Task<int> AddAsync([FromBody] CarModel model, CancellationToken token)
        {
            var dto = _mapper.Map<CarModel, CarDto>(model);
            return await _service.CreateCar(dto, token);
        }

        [HttpPut]
        public async Task<IActionResult> EditAsync([FromRoute] int id, [FromBody] CarModel model, CancellationToken token)
        {
            var dto = _mapper.Map<CarModel, CarDto>(model);
            await _service.UpdateCar(id, dto, token);
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int id, CancellationToken token)
        {
            await _service.DeleteCar(id, token);
        }
    }
}
