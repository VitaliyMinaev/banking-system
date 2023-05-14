using System.Security.Claims;

namespace BankingSystem.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static (bool, Guid) TryGetUserId(this ClaimsPrincipal user)
    {
        if (user.Identity.IsAuthenticated == false)
            throw new InvalidOperationException("Can not get user id from not authenticated user");
        
        var claimValue = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (String.IsNullOrEmpty(claimValue))
        {
            return (false, Guid.Empty);
        }
        
        var id = Guid.Empty;
        if (Guid.TryParse(claimValue, out id))
        {
            return (true, id);
        }

        return (false, Guid.Empty);
    }
}