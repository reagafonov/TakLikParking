using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User:IdentityUser
{
    public int Id { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public string LastName { get; set; }
    
    public string FirstName { get; set; }
    
    public string MiddleName { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }
}