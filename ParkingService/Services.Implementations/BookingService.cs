﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
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

    public async Task<int> AddBookingAsync(AddBookingModel model, CancellationToken cancellationToken)
    {
        var bookingToAdd = _mapper.Map<Booking>(model);

        var addedBooking = await _repository.AddAsync(bookingToAdd);
        await _repository.SaveChangesAsync(cancellationToken);

        return addedBooking.Id;
    }

    public async Task UpdateBookingAsync(UpdateBookingModel model, CancellationToken cancellationToken)
    {
        var booking = await _repository.GetAsync(model.Id);
        
        if (booking is null)
            throw new EntityNotFoundException(Messages.EntityNotFound);

        booking.PersonId = model.PersonId;
        booking.ParkingPlaceId = model.ParkingPlaceId;
        booking.CarId = model.CarId;
        booking.PaymentId = model.PaymentId;
        booking.StartDate = model.StartDate;
        booking.EndDate = model.EndDate;
        booking.Price = model.Price;
        
        await _repository.SaveChangesAsync(cancellationToken);
    }
}