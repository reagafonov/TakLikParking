namespace WebApi.Models;

[Flags]
public enum RolesEnum
{
    Client = 0,
    ParkingAdmin = 1,
    SuperAdmin = 2,
    Parking = 3,
}