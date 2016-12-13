using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace Eodg.FirebaseAuthentication
{
    public class FirebaseAuthenticationHandler : AuthorizationHandler<FirebaseAuthenticationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FirebaseAuthenticationRequirement requirement)
        {
            var mvcContext = context.Resource as AuthorizationFilterContext;
            if (mvcContext == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            string jwt = null;
            string authorization = mvcContext.HttpContext.Request.Headers["Authorization"];

            if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                jwt = authorization.Substring("Bearer ".Length).Trim();
            }

            // If no token found, no further work possible
            if (string.IsNullOrEmpty(jwt))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            try
            {
                SecurityToken token;    // TODO: Should we do somehting with this token???
                mvcContext.HttpContext.User = requirement.Auth.ValidateToken(jwt, out token);

                context.Succeed(requirement);
            }
            catch (Exception ex)
            {
                // TODO: Something with the exception probably...
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
