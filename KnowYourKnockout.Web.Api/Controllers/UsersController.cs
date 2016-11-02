using KnowYourKnockout.Business;
using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Exceptions;
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

        // TODO: Actually implement this...
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private UserLogic _userLogic;

        // TODO: Get rid of this...
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
                return StatusCode(500, new KykExceptionResponse(ex));
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _userLogic.GetUser(id);

                if (user == null)
                {
                    // TODO: Make a standard error class...
                    return NotFound(new Exception(string.Format("User not found with id: {0}", id)));
                }

                return Json(new KykSuccessResponse<User>(user));
            }
            catch (Exception ex)
            {
                // TODO: FIGURE OUT WHAT THIS SHOULD ACTUALLY BE!
                return StatusCode(500, new KykExceptionResponse(ex));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]User user)
        {
            // Validation
            var errors = new List<KykApiError>();

            if (!ModelState.IsValid)
            {
                errors.AddRange(GenerateErrorsForInvalidModelState());
            }

            if (_userLogic.UserExists(user.EmailAddress))
            {
                errors.Add(new KykApiError
                {
                    Resource = "Users",
                    Field = "emailAddress",
                    ErrorCode = KykApiErrorCode.UniqueValueForFieldAlreadyExists,
                    Message = string.Format(
                        "An account already exists for this email address: {0}", 
                        user.EmailAddress)
                });
            }

            if (errors.Count > 0)
            {
                return StatusCode(422, new KykErrorResponse(errors));
            }
            // END Validation

            try
            {
                user = _userLogic.AddUser(user);
                var response = new KykSuccessResponse<User>(user);

                return CreatedAtRoute(user.Id, response);
            }
            //catch(KykDataLayerException ex)
            //{

            //}
            catch(Exception ex)
            {
                // TODO: FIGURE OUT WHAT THIS SHOULD ACTUALLY BE!
                return StatusCode(500, new KykExceptionResponse(ex));
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]User user)
        {
            try
            {
                if (id != user.Id)
                {
                    return StatusCode(422, new KykExceptionResponse(new Exception("Ids do not match")));
                }

                if (_userLogic.GetUser(id) == null)
                {
                    return NotFound();
                }

                if (_userLogic.UpdateUserProfile(user))
                {
                    return NoContent();
                }
                else
                {
                    throw new Exception("Unknown error...");
                }                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new KykExceptionResponse(ex));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
                    throw new Exception("Error deleting user");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new KykExceptionResponse(ex));
            }
        }

        private List<KykApiError> GenerateErrorsForInvalidModelState()
        {
            var errors = new List<KykApiError>();

            foreach (var error in ModelState)
            {
                errors.Add(new KykApiError("Users",ConvertToCamelCase(error.Key), KykApiErrorCode.InvalidValueForField, error.Value.Errors[0].ErrorMessage));
            }

            return errors;
        }

        private static string ConvertToCamelCase(string s)
        {
            return s.Substring(0, 1).ToLower() + s.Substring(1);
        }
    }
}
