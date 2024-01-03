namespace Domain.Entities;

public class Wallet : IEntity<int>
{
    public int Id { get; set; }
    
    public int PersonId { get; set; }
    public virtual Person Person { get; set; }
    
    public decimal Balance { get; set; }
}