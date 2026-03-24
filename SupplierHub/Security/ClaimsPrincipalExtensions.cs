// /SupplierHub/Security/ClaimsPrincipalExtensions.cs
using System.Security.Claims;

namespace SupplierHub.Security
{
    public static class ClaimsPrincipalExtensions
    {
        public static long? GetUserId(this ClaimsPrincipal user)
        {
            var id = user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? user.FindFirstValue(ClaimTypes.Name);

            return long.TryParse(id, out var uid) ? uid : (long?)null;
        }

        public static string? GetUserName(this ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.Name);

        public static string? GetEmail(this ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.Email);

        public static bool IsInRoleAny(this ClaimsPrincipal user, params string[] roles)
            => roles.Any(user.IsInRole);
    }
}