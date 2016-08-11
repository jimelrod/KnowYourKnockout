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
        private TagLogic _tagLogic;

        public TagsController(TagLogic tagLogic)
        {
            _tagLogic = tagLogic;
        }

        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            return _tagLogic.GetTags();
        }
    }
}
