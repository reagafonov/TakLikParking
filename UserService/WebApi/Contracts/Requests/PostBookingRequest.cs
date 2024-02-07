namespace WebApi.Contracts.Requests;

public class PostBookingRequest
{
    public int PersonId { get; set; }
    
    public int ParkingPlaceId { get; set; }
    
    public int CarId { get; set; }
    
    public int PaymentId { get; set; }
    
    public DateTimeOffset StartDate { get; set; }
    
    public DateTimeOffset EndDate { get; set; }
    
    public decimal Price { get; set; }
}