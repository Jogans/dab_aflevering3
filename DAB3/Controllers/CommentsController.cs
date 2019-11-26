using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAB3.Models;
using DAB3.Services;
using Microsoft.AspNetCore.Mvc;

namespace DAB3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsService _commentsService;

        public CommentsController(CommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        public ActionResult<List<Comments>> Get() =>
            _commentsService.Get();

        [HttpGet("{id:length(24)}", Name = "GetComment")]
        public ActionResult<Comments> Get(string id)
        {
            var comment = _commentsService.Get(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        [HttpPost]
        public ActionResult<Comments> Create(Comments comment)
        {
            _commentsService.Create(comment);

            return CreatedAtRoute("GetComment", new { id = comment.Id.ToString() }, comment);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Comments commentIn)
        {
            var comment = _commentsService.Get(id);

            if (comment == null)
            {
                return NotFound();
            }

            _commentsService.Update(id, commentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var comment = _commentsService.Get(id);

            if (comment == null)
            {
                return NotFound();
            }

            _commentsService.Remove(comment.Id);

            return NoContent();
        }
    }
}
