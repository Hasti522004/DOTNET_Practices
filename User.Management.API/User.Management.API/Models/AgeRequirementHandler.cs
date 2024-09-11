using Microsoft.AspNetCore.Authorization;

namespace User.Management.API.Models
{
    public class AgeRequirementHandler : AuthorizationHandler<AgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
        {
            if(!context.User.HasClaim(claim => claim.Type == "age"))
            {
                return Task.CompletedTask;
            }
            if(!int.TryParse(context.User.FindFirst(c => c.Type == "age").Value, out int actualAge))
            {
                return Task.CompletedTask;
            }
            if(actualAge >= requirement.Age)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
