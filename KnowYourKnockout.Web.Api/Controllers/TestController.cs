using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KnowYourKnockout.Data.Models;
using KnowYourKnockout.Web.Api.Models;

namespace KnowYourKnockout.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new List<User>
            {
                new User
                {
                    Id = 123,
                    DisplayName = string.Format("{0} - Jim", 642)
                },
                new User
                {
                    Id = 345,
                    DisplayName = string.Format("{0} - Jim", 235)
                }
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(new User
            {
                Id = 456,
                DisplayName = string.Format("{0} - Jim", id)
            });
        }

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
