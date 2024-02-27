// using AutoMapper;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.ApplicationModels;
// using Services.Abstractions;
// using Services.Contracts;
// using WebApi.Contracts.Dtos;
//
// namespace WebApi.Controllers;
//
// // [ApiController]
// // [Route ("api/[controller]")]
// [Obsolete]
// public abstract class CommonController<TApiDto, TServiceDto, TModel, TKey>:ControllerBase 
//     where TApiDto:class
//     where TServiceDto:class 
//     where TModel:class
//     where TKey:struct 
// {
//     private readonly ICommonCrudService<TServiceDto, TKey> _crudService;
//     private readonly IMapper _mapper;
//
//     public CommonController(ICommonCrudService<TServiceDto, TKey> crudService, IMapper mapper)
//     {
//         _crudService = crudService;
//         _mapper = mapper;
//     }
//
//     [HttpGet("{id}")]
//     public virtual async Task<IActionResult> GetByID([FromRoute] TKey id, CancellationToken token)
//     {
//         var businessDto = await _crudService.GetByID(id, token);
//         var roleApiDto = _mapper.Map<TApiDto>(businessDto);
//         return Ok(roleApiDto);
//     }
//
//
//     [HttpGet("items-per-page/{itemPerPage:int}/page/{page:int}")]
//     public virtual async Task<IActionResult> GetPages([FromRoute] int page, [FromRoute] int itemPerPage,
//         CancellationToken token)
//     {
//         var pagedData = await _crudService.GetPaged(page, itemPerPage, token);
//         var mapped = _mapper.Map<List<TApiDto>>(pagedData);
//         return Ok(mapped);
//     }
//     
//     
//     [HttpPost]
//     public virtual async Task<TKey> AddAsync([FromBody]TModel model, CancellationToken token)
//     {
//         var dto = _mapper.Map<TModel, TServiceDto>(model);
//         return await _crudService.Create(dto, token);
//     }
//
//     [HttpPut("{id}")]
//     public virtual async Task<IActionResult> EditAsync([FromRoute]TKey id, [FromBody]TModel model, CancellationToken token)
//     {
//         var dto = _mapper.Map<TModel, TServiceDto>(model); 
//         await _crudService.Update(id, dto, token);
//         return Ok();
//     }
//
//     [HttpDelete]
//     public async Task Delete(TKey id, CancellationToken token)
//     {
//         await _crudService.DeleteAsync(id, token);
//     }
//     
//    // public async 
// }