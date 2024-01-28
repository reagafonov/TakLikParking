using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Clients.ParkingService;

public interface IParkingServiceClient
{
    public Task<List<ParkingResultModel>?> GetPage(int page, int itemPerPage, CancellationToken token);
    public Task<ParkingResultModel?> GetAsync(int id);
    public Task<int> AddAsync(ParkingModel model, CancellationToken token);
    public Task<int> EditAsync(int id, ParkingModel model, CancellationToken token);
    public Task Delete(int id, CancellationToken token);
}
