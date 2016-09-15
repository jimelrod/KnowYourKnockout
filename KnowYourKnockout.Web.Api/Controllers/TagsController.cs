using KnowYourKnockout.Business;
using KnowYourKnockout.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        //private TagLogic _tagLogic;

        //public TagsController(TagLogic tagLogic)
        //{
        //    _tagLogic = tagLogic;
        //}

        //[HttpGet]
        //public IActionResult Get()
        //{   
        //    Exception ex;
        //    var tags = _tagLogic.GetTags(out ex);

        //    return ex == null ? Json(tags) : Json(ex);
        //}
    }
}
