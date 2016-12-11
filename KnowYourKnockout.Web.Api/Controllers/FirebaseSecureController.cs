using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KnowYourKnockout.Web.Api.Controllers
{
    [RequireHttps]
    [Authorize("FirebaseJwt")]
    public abstract class FirebaseSecureController : Controller
    {
        public string UserId
        {
            get
            {
                return HttpContext.User.Claims.Single(c => c.Type == "user_id").Value;
            }
        }
    }
}
