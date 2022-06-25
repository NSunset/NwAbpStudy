using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sample.HttpApi.Unitily
{
    public class CustomNameAuthorizationHandler : AuthorizationHandler<NameRequirement>
    {
        public CustomNameAuthorizationHandler()
        {

        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, NameRequirement requirement)
        {
            if (context.User != null && context.User.Claims.Any(x => x.Type == ClaimTypes.Name))
            {
                var value = context.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name).Value;

                if (value == "admin")
                {
                    await Task.Yield();
                    context.Succeed(requirement);
                }
            }
        }
    }
}
