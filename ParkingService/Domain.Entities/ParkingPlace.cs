namespace Domain.Entities;

public class ParkingPlace : IEntity<int>
{
    public int Id { get; set; }

    public ParkingPlaceType Type { get; set; }
    public int Number { get; set; }
    public ParkingPlaceStatus Status { get; set; }
    public bool IsAvailable { get; set; }
    public decimal Cost { get; set; }
    
    public int ParkingId { get; set; }  
    public virtual Parking Parking { get; set; }  
}