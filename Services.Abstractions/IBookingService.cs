using Services.Contracts;
using Services.Contracts.Models;

namespace Services.Abstractions;

public interface IBookingService
{
    Task<GetBookingsResponseModel> GetBookingsAsync(GetBookingsModel model, CancellationToken cancellationToken);
    Task<BookingDto> GetBookingIdAsync(int id, CancellationToken cancellationToken);
    Task DeleteBookingAsync(int id, CancellationToken cancellationToken);
}