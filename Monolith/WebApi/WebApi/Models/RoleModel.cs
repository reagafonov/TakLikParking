using Domain.Entities;

namespace WebApi.Models;

public class RoleModel
{
    public string Name { get; init; }
    public Access Access { get; init; }
}
