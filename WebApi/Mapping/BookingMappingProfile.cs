using AutoMapper;
using Domain.Entities;
using Services.Contracts;
using Services.Contracts.Filters;
using Services.Contracts.Models;
using WebApi.Contracts.Dtos;
using WebApi.Contracts.Requests;
using WebApi.Contracts.Responses;

namespace WebApi.Mapping;

public class BookingMappingProfile : Profile
{
    public BookingMappingProfile()
    {
        CreateMap<GetBookingsRequest, GetBookingsModel>();
        CreateMap<GetBookingsModel, GetBookingsRepositoryFilter>();
        CreateMap<Booking, BookingDto>();
        CreateMap<BookingDto, BookingApiDto>();
        CreateMap<GetBookingsResponseModel, GetBookingsApiResponse>();
        
        CreateMap<PostBookingRequest, AddBookingModel>();
        CreateMap<AddBookingModel, Booking>();
    }
}