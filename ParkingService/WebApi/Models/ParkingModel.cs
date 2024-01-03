using System.Text;

namespace WebApi.Models;

public class ParkingModel
{
    public string? District { get; init; }

    public string City { get; init; }
    
    public string Street { get; init; }
    
    public string Building { get; init; }

    public string GetAddress() => new string[] {District, City, Street, Building}
        .Where(x => !string.IsNullOrWhiteSpace(x))
        .Aggregate(new StringBuilder(),
            (a, c) => a.Append(c).Append(','),
            a => a.ToString().TrimEnd(','));

}