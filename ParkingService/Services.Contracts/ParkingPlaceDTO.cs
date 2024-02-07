namespace Services.Contracts;

public class ParkingPlaceDTO
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public bool Available { get; set; }
    public decimal Cost { get; set; }
}