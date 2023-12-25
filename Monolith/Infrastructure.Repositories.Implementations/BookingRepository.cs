using Domain.Entities;
using Infrastructure.EntityFramework;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations;

public class BookingRepository: Repository<Booking, int>, IBookingRepository
{
    public BookingRepository(DatabaseContext context) : base(context)
    {
    }
}