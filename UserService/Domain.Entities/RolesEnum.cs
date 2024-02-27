namespace WebApi.Models;

[Flags]
public enum RolesEnum:int
{
    Client = 0,
    ParkingAdmin = 1,
    SuperAdmin = 2,
    Parking = 3,
}