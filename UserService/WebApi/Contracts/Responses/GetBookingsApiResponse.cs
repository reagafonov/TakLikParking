using WebApi.Contracts.Dtos;

namespace WebApi.Contracts.Responses;

public class GetBookingsApiResponse
{
    public IEnumerable<BookingApiDto> Data { get; set; }
    public int Count => Data.Count();
}