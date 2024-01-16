using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using WebApi.Models;
using Asp.Versioning;

namespace WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonService _service;
        private IMapper _mapper;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonService service, ILogger<PersonController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]PersonModel personModel)
        {
            return Ok(await _service.Create(_mapper.Map<PersonDto>(personModel)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]PersonModel personModel)
        {
            await _service.Update(id, _mapper.Map<PersonDto>(personModel));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<PersonResultModel>(await _service.GetById(id)));
        }

        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetList(int page, int itemsPerPage)
        {
            return Ok(_mapper.Map<List<PersonResultModel>>(await _service.GetPaged(page, itemsPerPage)));
        }
    }
}