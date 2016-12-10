using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [RequireHttps]

    public class SignInController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult SignUp()
        {
            return Ok();
        }
    }
}
