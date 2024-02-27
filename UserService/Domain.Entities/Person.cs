namespace Domain.Entities;

public class Person : IEntity<int>
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    
    public string Creator { get; set; }
    
    public string FullName => $"{LastName} {FirstName} {MiddleName}";
}