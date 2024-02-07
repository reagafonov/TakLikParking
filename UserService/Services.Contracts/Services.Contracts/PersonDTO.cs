namespace Services.Contracts;

public class PersonDTO
{
    public int Id { get; set; }
   
    public string LastName { get; set; }
    
    public string FirstName { get; set; }
    
    public string MiddleName { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }
    
    public int RoleId { get; set; }
    
    public string RoleName { get; set; }
    
    //public virtual Role Role { get; set; }
    
    public string FullName { get; }
}

// namespace Services.Contracts;
//
// public class PersonDto
// {
//     public int Id { get; set; }
//     public string LastName { get; set; } = string.Empty;
//     public string FirstName { get; set; } = string.Empty;
//     public string MiddleName { get; set; } = string.Empty;
//     public string Phone { get; set; } = string.Empty;
//     public string Email { get; set; } = string.Empty;
//     public int RoleId { get; set; }
// }
