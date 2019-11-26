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
    public class UserController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UserController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public ActionResult<List<Users>> Get() =>
            _usersService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<Users> Get(string id)
        {
            var user = _usersService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<Users> Create(Users user)
        {
            _usersService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Users userIn)
        {
            var user = _usersService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _usersService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _usersService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _usersService.Remove(user.Id);

            return NoContent();
        }
    }
}
