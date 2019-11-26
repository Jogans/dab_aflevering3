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
    public class PostsController : ControllerBase
    {
        private readonly PostsService _postsService;

        public PostsController(PostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        public ActionResult<List<Posts>> Get() =>
            _postsService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPost")]
        public ActionResult<Posts> Get(string id)
        {
            var post = _postsService.Get(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        [HttpPost]
        public ActionResult<Posts> Create(Posts post)
        {
            _postsService.Create(post);

            return CreatedAtRoute("GetPost", new { id = post.Id.ToString() }, post);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Posts postIn)
        {
            var post = _postsService.Get(id);

            if (post == null)
            {
                return NotFound();
            }

            _postsService.Update(id, postIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var post = _postsService.Get(id);

            if (post == null)
            {
                return NotFound();
            }

            _postsService.Remove(post.Id);

            return NoContent();
        }
    }
}
