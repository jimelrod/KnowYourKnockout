using KnowYourKnockout.Business;
using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private UserLogic _userLogic;

        public UsersController(UserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_userLogic.GetUsers());
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            try
            {
                return new User
                {
                    Id = Guid.NewGuid(),
                    DisplayName = string.Format("{0} - Jim", id)
                };
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        [HttpPost]
        public User Post(User user)
        {
            try
            {
                user = _userLogic.AddUser(user);
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                user = null;
            }

            return user;
        }
    }
}
