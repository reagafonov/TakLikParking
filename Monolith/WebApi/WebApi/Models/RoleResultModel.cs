using Domain.Entities;

namespace WebApi.Models;

public class RoleResultModel
{
    public int Id { get; init; }
    public string Name { get; init; }
    public Access Access { get; init; }
}
