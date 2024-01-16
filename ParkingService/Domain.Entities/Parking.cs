namespace Domain.Entities;

public class Parking : IEntity<int>
{
    public int Id { get; set; }

    public string Address { get; set; }
    public virtual ICollection<ParkingPlace> ParkingPlaces { get; set; }  
}