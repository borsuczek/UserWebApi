using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    // Controller responsible for managing HTTP requests
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(User), 200)]
        [Produces("application/json")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
                return NotFound();


            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), 201)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public IActionResult AddUser([FromBody] CreateUserDto userDto)
        {
            // Create a user based on userDto values
            var user = new User();
            user.Name = userDto.Name;
            user.Phone = userDto.Phone;
            user.Email = userDto.Email;

            _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public IActionResult UpdateUser(int id, [FromBody] CreateUserDto userDto)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            // Update only the properties provided in the UserUpdateDto
            user.Name = userDto.Name;
            user.Phone = userDto.Phone;
            user.Email = userDto.Email;

            _userService.UpdateUser(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}