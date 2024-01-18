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
        
        CreateMap<PutBookingRequest, UpdateBookingModel>()
            .ForMember(d => d.PersonId, opt => opt.MapFrom(s => s.Body.PersonId))
            .ForMember(d => d.ParkingPlaceId, opt => opt.MapFrom(s => s.Body.ParkingPlaceId))
            .ForMember(d => d.CarId, opt => opt.MapFrom(s => s.Body.CarId))
            .ForMember(d => d.PaymentId, opt => opt.MapFrom(s => s.Body.PaymentId))
            .ForMember(d => d.StartDate, opt => opt.MapFrom(s => s.Body.StartDate))
            .ForMember(d => d.EndDate, opt => opt.MapFrom(s => s.Body.EndDate))
            .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Body.Price))
            ;
    }
}