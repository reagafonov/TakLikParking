namespace Domain.Entities;

public class Car : IEntity<int>
{
    public int Id { get; set; }
    public string Colour { get; set; }
    public string Number { get; set; }
    
    public virtual ICollection<Booking> Bookings { get; set; }
}