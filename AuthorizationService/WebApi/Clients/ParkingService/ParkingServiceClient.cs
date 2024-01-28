using AutoMapper;
using Services.Contracts;
using System.Net;
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

    public async Task Delete(int id, CancellationToken token)
    {
        using var response = await _client.DeleteAsync($"https://localhost:1000/api/Parking/{id}", token);
    }

    public async Task<int> EditAsync(int id, ParkingModel model, CancellationToken token)
    {
        var dto = _mapper.Map<ParkingModel, ParkingDTO>(model);
        dto.Id = id;
        using var response = await _client.PutAsJsonAsync("https://localhost:1000/api/Parking/", dto);

        return (int)response.StatusCode;
    }

    public async Task<ParkingResultModel?> GetAsync(int id)
    {
        using var response = await _client.GetAsync($"https://localhost:1000/api/Parking/{id}");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<ParkingResultModel>();
        }

        //TO-DO прописать ошибку
        Console.WriteLine("Элемент не найден");
        return null;
    }

    public async Task<List<ParkingResultModel>?> GetPage(int page, int itemPerPage, CancellationToken token)
    {
        using var response = await _client.GetAsync($"https://localhost:1000/api/Parking/list/{page}/{itemPerPage}", token);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<List<ParkingResultModel>>();
        }

        //TO-DO прописать ошибку
        Console.WriteLine("Элемент не найден");
        return null;
    }
}
