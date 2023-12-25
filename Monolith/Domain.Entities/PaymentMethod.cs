namespace Domain.Entities;

public class PaymentMethod : IEntity<int>
{
    public int Id { get; set; }
    public int Description { get; set; }
    
    public virtual ICollection<Payment> Payments { get; set; } 
}