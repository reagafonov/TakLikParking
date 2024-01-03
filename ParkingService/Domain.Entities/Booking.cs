namespace Domain.Entities;

public class Booking : IEntity<int>
{
    public int Id { get; set; }
    
    public int PersonId { get; set; }
    public virtual Person Person { get; set; }
    
    public int ParkingPlaceId { get; set; }
    public virtual ParkingPlace ParkingPlace { get; set; }  
    
    public int CarId { get; set; }
    public virtual Car Car { get; set; }  
    
    public int PaymentId { get; set; }
    public virtual Payment Payment { get; set; }  
    
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    
    public decimal Price { get; set; }
    public BookingStatus Status { get; set; }
}