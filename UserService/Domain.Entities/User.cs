using System.Diagnostics;

namespace Domain.Entities;

public class User:IEntity<int>
{
    public int Id { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public virtual ICollection<Role> Roles { get; set; } 
}