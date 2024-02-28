using Services.Contracts.Abstractions;

namespace Services.Contracts.Filters;

public class GetBookingsRepositoryFilter : IPage
{
    public int Skip { get; set; }
    public int Take { get; set; }
}