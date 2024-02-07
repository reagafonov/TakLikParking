using Microsoft.AspNetCore.Mvc;

namespace WebApi.Contracts.Requests;

public class PutBookingRequest
{
    [FromRoute]
    public int Id { get; set; }

    [FromBody]
    public PutBookingRequestBody Body { get; set; }
}

public class PutBookingRequestBody
{
    public int PersonId { get; set; }
    
    public int ParkingPlaceId { get; set; }
    
    public int CarId { get; set; }
    
    public int PaymentId { get; set; }
    
    public DateTimeOffset StartDate { get; set; }
    
    public DateTimeOffset EndDate { get; set; }
    
    public decimal Price { get; set; }
}