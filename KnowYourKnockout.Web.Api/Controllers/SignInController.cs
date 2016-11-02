using KnowYourKnockout.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace KnowYourKnockout.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class SignInController : Controller
    {
        [HttpPost]
        public IActionResult SignIn([FromBody]string token)
        //public IActionResult SignIn([FromBody]FirebaseUser user)
        {
            Console.Write("Pause");

            var tokenHandler = new JwtSecurityTokenHandler();

            var readToken = tokenHandler.ReadJwtToken(token);
            
            return Json(readToken);
        }
    }
}
