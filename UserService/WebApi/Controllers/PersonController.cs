using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Services.Contracts.Filters;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [Authorize]
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
            var personDto = _mapper.Map<PersonDto>(personModel);
            personDto.Owner = User.Identity.Name;
            return Ok(await _service.Create(personDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]PersonModel personModel)
        {
            var personDto = await _service.GetById(id, default);
            if (!User.IsInAdmin() && personDto.Owner != User.Identity.Name)
                return Forbid();
            await _service.Update(id, _mapper.Map<PersonDto>(personModel));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            var personDto = await _service.GetById(id, token);
            if (!User.IsInAdmin() && personDto.Owner != User.Identity.Name)
                return Forbid();
            await _service.Delete(id, token);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken token)
        {
            var personDto = await _service.GetById(id, token);
            if (!User.IsInAdmin() && personDto.Owner != User.Identity.Name)
                return Forbid();
            return Ok(_mapper.Map<PersonResultModel>(personDto));
        }

        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetList(int page, int itemsPerPage)
        {
            var filter = new PersonFilter();
            if (!User.IsInAdmin())
            {
                filter.Owner = User.Identity.Name;
            }

            return Ok(_mapper.Map<List<PersonResultModel>>(await _service.GetPaged(filter,page, itemsPerPage)));
        }
    }
}