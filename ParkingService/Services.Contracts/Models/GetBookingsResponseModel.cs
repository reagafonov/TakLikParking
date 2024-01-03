namespace Services.Contracts.Models;

public class GetBookingsResponseModel
{
    public IEnumerable<BookingDto> Data { get; set; }
    public int Count => Data.Count();
}