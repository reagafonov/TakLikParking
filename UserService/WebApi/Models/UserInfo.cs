using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace WebApi.Models;

public class UserInfo//:PersonModel
{
    public string UserName { get; set; }
    
    [PasswordPropertyText]
    public string  Password { get; set; }
    
    public RolesEnum[] Roles { get; set; }
    
}