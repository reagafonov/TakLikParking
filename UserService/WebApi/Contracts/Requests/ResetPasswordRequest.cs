namespace WebApi.Models;

public class ResetPasswordRequest
{
    public string Login { get; set; }
    
    public string OldPassword { get; set; }
    
    public string NewPassword { get; set; }
}