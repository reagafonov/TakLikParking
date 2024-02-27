using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace WebApi.Models;

public class PersonModel
{
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    //TODO: переделать на RoleModel 
    // public virtual Role? Role { get; set; }

    //public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
    //public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    //public virtual ICollection<Car> Cars { get; set; } = new List<Car>();


}
