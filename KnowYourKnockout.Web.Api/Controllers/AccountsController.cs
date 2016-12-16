using Eodg.FirebaseAuthentication;
using KnowYourKnockout.Business;
using KnowYourKnockout.Data.Models;
using KnowYourKnockout.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : FirebaseSecureController
    {
        UserLogic _userLogic;

        public AccountsController(UserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        //[HttpGet]
        //public IActionResult SignIn()
        //{
        //    return Ok();
        //}

        [HttpPost]
        public IActionResult SignUp([FromBody] FirebaseUser firebaseUser) 
        {
            // TODO: Validate model, probably...

            try
            {
                // TODO: Maybe use POCOs?
                var user = _userLogic.SignInUser(new User
                {
                    DisplayName = firebaseUser.DisplayName,
                    EmailAddress = firebaseUser.EmailAddress,
                    FirebaseId = firebaseUser.FirebaseId,
                    PhotoUrl = firebaseUser.PhotoUrl
                });

                var response = new KykSuccessResponse<User>(user);

                return Json(response);
            }
            catch(Exception ex)
            {
                // TODO: FIGURE OUT WHAT THIS SHOULD ACTUALLY BE!
                return StatusCode(500, new KykExceptionResponse(ex));
            }
        }
    }
}
