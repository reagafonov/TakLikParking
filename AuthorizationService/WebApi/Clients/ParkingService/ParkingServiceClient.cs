using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Net;
using System.Net.Http;
using WebApi.Models;

namespace WebApi.Clients.ParkingService;

public class ParkingServiceClient : IParkingServiceClient
{
    private readonly HttpClient _client;
    private readonly IMapper _mapper;
    public ParkingServiceClient(HttpClient client, IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public async Task<int> AddAsync(ParkingModel model, CancellationToken ct)
    {
        var request = $"https://localhost:1000/api/Parking/";
        var dto = _mapper.Map<ParkingModel, ParkingDTO>(model);
        using var responce = await _client.PostAsJsonAsync(request, dto);

        return (int)responce.StatusCode;
    }

    public Task Delete(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<int> EditAsync(int id, ParkingModel model, CancellationToken token)
    {
        var dto = _mapper.Map<ParkingModel, ParkingDTO>(model);
        dto.Id = id;
        using var response = await _client.PutAsJsonAsync("https://localhost:1000/api/Parking/", dto);

        return (int)response.StatusCode;
    }

    public Task<IActionResult> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetPage(int page, int itemPerPage, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
