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
        public IEnumerable<User> Get()
        {
            try
            {
                return _userLogic.GetUsers();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
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
                    FirstName = string.Format("{0} - Jim", id)
                };
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }
    }
}
