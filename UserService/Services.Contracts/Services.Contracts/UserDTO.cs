using WebApi.Models;

namespace Services.Contracts;

public class UserDTO
{
    public string ID { get; set; }
    
    public string Password { get; set; }
    
    public RolesEnum Roles { get; set; }
}