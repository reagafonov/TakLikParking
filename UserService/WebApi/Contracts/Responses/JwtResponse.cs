namespace WebApi.Models;

public class JwtResponse
{
    public bool IsAuthorized { get; set; }

    public string access_token { get; set; }
    
    public string Reason { get; set; }
}