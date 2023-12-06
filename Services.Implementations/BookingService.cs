using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Constants;
using Services.Contracts;
using Services.Contracts.Filters;
using Services.Contracts.Models;
using Services.Exceptions;
using Services.Repositories.Abstractions;

namespace Services.Implementations;

public class BookingService : IBookingService
{
    private readonly ILogger<BookingService> _logger;
    private readonly IBookingRepository _repository;
    private readonly IMapper _mapper;
    
    public BookingService(
        ILogger<BookingService> logger, 
        IBookingRepository repository, 
        IMapper mapper
    )
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<GetBookingsResponseModel> GetBookingsAsync(GetBookingsModel model, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<GetBookingsRepositoryFilter>(model);

        var result = await _repository
            .GetAll(true)
            .OrderBy(booking => booking.Id)
            .Skip(filter.Skip)
            .Take(filter.Take)
            .ProjectTo<BookingDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);

        return new GetBookingsResponseModel()
        {
            Data = result,
        };
    }

    public async Task<BookingDto> GetBookingIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _repository
            .GetAll()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        if (result is null)
            throw new EntityNotFoundException(Messages.EntityNotFound);
        
        return _mapper.Map<BookingDto>(result);
    }

    public async Task DeleteBookingAsync(int id, CancellationToken cancellationToken)
    {
        var isDeleted = _repository.Delete(id);
        if (!isDeleted)
            throw new EntityNotFoundException(Messages.EntityNotFound);
        
        await _repository.SaveChangesAsync(cancellationToken);
    }
}