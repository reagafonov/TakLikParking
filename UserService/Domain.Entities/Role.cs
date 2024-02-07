namespace Domain.Entities;

public class Role : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Access Access { get; set; }
    
    public virtual ICollection<Person> Persons { get; set; }
}