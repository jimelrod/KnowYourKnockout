using Microsoft.AspNetCore.Authorization;

namespace Eodg.FirebaseAuthentication
{
    public class FirebaseAuthenticationRequirement : IAuthorizationRequirement
    {
        public FirebaseAuthenticationRequirement(FirebaseAuthenticationSettings settings)
        {
            Auth = new FirebaseAuthenticationEngine(settings);
        }

        // HACK: THIS IS PROBABLY THE WRONG WAY TO GO ABOUT IT!!!
        internal FirebaseAuthenticationEngine Auth { get; set; }
    }
}
