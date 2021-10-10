using Case.BusinessLogic.Abstract;
using Case.Etity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case.WebApi.Controllers
{
    //[AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private IContentManager _contentService;

        public ContentsController(IContentManager contentService)
        {
            _contentService = contentService;
        }

        [HttpGet]
        public ActionResult GetList()
        {
            return Ok(_contentService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int Id)
        {
            return Ok(_contentService.GetById(Id));
        }

        [Authorize(Roles = "User, Admin")]
        [Route("Save")]
        [HttpPost]
        public ActionResult AddUpdate([FromBody] Content content)
        {
            var result = "";
            if (content.Id > 0)
            {
                result = _contentService.Update(content);
            }
            else
            {
                result = _contentService.Add(content);
            }
            return Ok(result);
        }

        [Authorize(Roles = "User, Admin")]
        [Route("Delete/{id}")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            return Ok(_contentService.Delete(id));
        }

        
    }
}
