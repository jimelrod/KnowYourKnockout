using KnowYourKnockout.Business;
using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using KnowYourKnockout.Utility;
using KnowYourKnockout.Web.Api.Models;
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
                var users = _userLogic.GetUsers();
                var response = new KykSuccessResponse<IEnumerable<User>>(users);

                return Json(response);
            }
            catch (Exception ex)
            {
                // TODO: FIGURE OUT WHAT THIS SHOULD ACTUALLY BE!
                return BadRequest(new KykErrorResponse(ex));
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var user = _userLogic.GetUser(id);
                var response = new KykSuccessResponse<User>(user);

                return Json(response);
            }
            catch (Exception ex)
            {
                return NotFound(new KykErrorResponse(ex));
            }
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                user = _userLogic.AddUser(user);
                var response = new KykSuccessResponse<User>(user);

                return CreatedAtRoute(user.Id, response);
            }
            catch(Exception ex)
            {
                return StatusCode(422, new KykErrorResponse(ex));
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, User user)
        {
            try
            {
                if (_userLogic.UpdateUserProfile(user))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }                
            }
            catch (Exception ex)
            {
                return StatusCode(422, new KykErrorResponse(ex));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var user = _userLogic.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }

                if (_userLogic.DeleteUser(user))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(422, new KykErrorResponse(ex));
            }
        }
    }
}
