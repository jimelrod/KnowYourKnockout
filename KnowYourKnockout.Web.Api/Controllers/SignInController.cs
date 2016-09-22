using KnowYourKnockout.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class SignInController : Controller
    {
        [HttpPost]
        public IActionResult SignIn([FromBody]FirebaseUser user)
        {
            Console.Write("Pause");



            return Json(user);
        }
    }
}
