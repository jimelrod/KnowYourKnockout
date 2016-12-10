using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KnowYourKnockout.Web.Api.Auth
{
    public class FirebaseAuthHandler : AuthorizationHandler<FirebaseAuthRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FirebaseAuthRequirement requirement)
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

            SecurityToken token;
            if (requirement.Auth.TryValidateToken(jwt, out token))
            {
                //mvcContext.HttpContext.
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
