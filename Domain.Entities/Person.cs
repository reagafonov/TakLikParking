namespace Domain.Entities;

public class Person : IEntity<int>
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public int FirstName { get; set; }
    public int MiddleName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
    
    public virtual ICollection<Wallet> Wallets { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }

    public string FullName => $"{LastName} {FirstName} {FirstName}";
}