namespace Services.Contracts;

public class PersonDto
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    
    public int RoleId { get; set; }
    
}
