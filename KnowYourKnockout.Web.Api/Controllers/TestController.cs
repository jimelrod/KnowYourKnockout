using Eodg.FirebaseAuthentication;
using KnowYourKnockout.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KnowYourKnockout.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : FirebaseSecureController
    {
        [HttpGet]
        public IActionResult Get()
        {
            var x = UserId;

            return Json(new List<User>
            {
                new User
                {
                    Id = 123,
                    DisplayName = string.Format("{0} - Jim", UserId)
                },
                new User
                {
                    Id = 345,
                    DisplayName = string.Format("{0} - Jim2", 235)
                }
            });
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(new User
            {
                Id = 456,
                DisplayName = string.Format("{0} - Jim", id)
            });
        }

        // TODO: Send a CreatedAt response?
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            user.DisplayName = string.Format("POST - {0}", user.DisplayName);
            return Json(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User user)
        {
            user.DisplayName = string.Format("PUT - Id: {0} - {1}", id, user.DisplayName);
            return Json(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
