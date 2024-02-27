using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using WebApi.Models;

namespace Domain.Entities;

public class User:IEntity<string>
{
    
    public string Password { get; set; }
    
    public RolesEnum Roles { get; set; }
    public string Id { get; set; }
}