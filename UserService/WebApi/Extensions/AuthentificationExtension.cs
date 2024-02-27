using System.Security.Claims;
using WebApi.Models;

namespace WebApi.Extensions;

public static class AuthentificationExtension
{
    public static bool IsInRole(this ClaimsPrincipal principal, RolesEnum role)
    {
        var roleName = Enum.GetName(role).Split('.').Last();
        return principal.Identity.IsAuthenticated &&
               principal.HasClaim(x => x.Type == ClaimTypes.Role && x.Value == roleName);
    }
    
    public static bool IsInAdmin(this ClaimsPrincipal principal)
    {
        return IsInRole(principal,RolesEnum.SuperAdmin) || IsInRole(principal,RolesEnum.ParkingAdmin) ||
               IsInRole(principal,RolesEnum.Parking);
    }

    public static string GetRoleName(this RolesEnum role) => Enum.GetName(role).Split('.').Last();
}