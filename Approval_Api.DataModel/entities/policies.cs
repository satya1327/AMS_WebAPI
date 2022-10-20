using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approval_Api.DataModel_.entities
{
    public class Policies
    {
        public static AuthorizationPolicy AdminPolicy()
        
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole("2")
                                                   .Build();
        }
    }
}
