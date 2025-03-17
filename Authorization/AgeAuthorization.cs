using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MoviesAPI.Authorization;

public class AgeAuthorization : AuthorizationHandler<MinimumAge>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
    {
        var birthDateClaim = context
            .User.FindFirst(claim =>
            claim.Type == ClaimTypes.DateOfBirth);
        
        System.Console.WriteLine(birthDateClaim);

        if(birthDateClaim is null) return Task.CompletedTask;

        var birthDate = Convert.ToDateTime(birthDateClaim.Value);
        var userAge = DateTime.Today.Year - birthDate.Year;

        if (birthDate > DateTime.Today.AddYears(-userAge)) userAge--;
        if (userAge >= requirement.Age) context.Succeed(requirement);

        return Task.CompletedTask;
    }
}