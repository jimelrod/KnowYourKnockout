using KnowYourKnockout.Business;
using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using KnowYourKnockout.Utility;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        const string CLASS_NAME = "KnowYourKnockout.Web.Api.Controllers.UsersController";

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private UserLogic _userLogic;
        private Log _log;

        public UsersController(UserLogic userLogic, Log log)
        {
            _userLogic = userLogic;
            _log = log;
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
                _log.Insert(ex.Message, CLASS_NAME, "Get()");
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            try
            {
                //return new User
                //{
                //    Id = Guid.NewGuid(),
                //    DisplayName = string.Format("{0} - Jim", id)
                //};

                return _userLogic.GetUser(id);

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
