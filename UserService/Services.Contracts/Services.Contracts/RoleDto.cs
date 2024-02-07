using Domain.Entities;

namespace Services.Contracts;
public class RoleDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Access Access { get; set; }
}
