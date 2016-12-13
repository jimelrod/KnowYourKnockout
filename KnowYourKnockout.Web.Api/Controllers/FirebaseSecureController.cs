using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace KnowYourKnockout.Web.Api.Controllers
{
    [RequireHttps]
    [Authorize("FirebaseSecure")]
    public abstract class FirebaseSdecureController : Controller
    {
        private string _userId = null;

        public string UserId
        {
            get
            {
                if (string.IsNullOrEmpty(_userId))
                {
                    try
                    {
                        _userId = HttpContext.User.Claims.Single(c => c.Type == "user_id").Value;
                    }
                    catch(Exception ex)
                    {
                        // TODO: Should probably do something with the exception...
                        throw ex;
                    }
                }

                return _userId;
            }
        }
    }
}
