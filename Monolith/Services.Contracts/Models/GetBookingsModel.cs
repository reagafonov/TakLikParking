using Services.Contracts.Abstractions;

namespace Services.Contracts.Models;

public class GetBookingsModel : IPage
{
    public int Skip { get; set; }
    public int Take { get; set; }
}