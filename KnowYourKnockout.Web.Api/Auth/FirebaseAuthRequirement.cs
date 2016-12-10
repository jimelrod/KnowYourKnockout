using EODG.FirebaseAuthTool;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Web.Api.Auth
{
    public class FirebaseAuthRequirement : IAuthorizationRequirement
    {
        public FirebaseAuthRequirement(string projectId)
        {
            Auth = new FirebaseAuth(projectId);
        }

        // THIS IS PROBABLY THE WRONG WAY TO GO ABOUT IT!!!
        public FirebaseAuth Auth { get; set; }
    }
}
