using Services.Contracts.Abstractions;

namespace WebApi.Contracts.Requests;

public class GetBookingsRequest : IPage
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}