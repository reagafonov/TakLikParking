namespace Domain.Entities;

public class Payment : IEntity<int>
{
    public int Id { get; set; }
    
    public int PaymentMethodId { get; set; }
    public virtual PaymentMethod PaymentMethod { get; set; }
    
    public virtual ICollection<Booking> Bookings { get; set; }
}