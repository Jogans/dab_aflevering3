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
    public class CircleController : ControllerBase
    {
        private readonly CirclesService _circlesService;

        public CircleController(CirclesService circlesService)
        {
            _circlesService = circlesService;
        }

        [HttpGet]
        public ActionResult<List<Circle>> Get() =>
            _circlesService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCircle")]
        public ActionResult<Circle> Get(string id)
        {
            var circle = _circlesService.Get(id);

            if (circle == null)
            {
                return NotFound();
            }

            return circle;
        }

        [HttpPost]
        public ActionResult<Comments> Create(Circle circle)
        {
            _circlesService.Create(circle);

            return CreatedAtRoute("GetCircle", new { id = circle.Id.ToString() }, circle);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Circle circleIn)
        {
            var circle = _circlesService.Get(id);

            if (circle == null)
            {
                return NotFound();
            }

            _circlesService.Update(id, circleIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var circle = _circlesService.Get(id);

            if (circle == null)
            {
                return NotFound();
            }

            _circlesService.Remove(circle.Id);

            return NoContent();
        }

    }
}

