namespace WebApi.Models;

[Flags]
public enum RolesEnum:int
{
    Client = 1,
    ParkingAdmin = 1<<1,
    SuperAdmin = 1<<2,
    Parking = 1<<3,
}