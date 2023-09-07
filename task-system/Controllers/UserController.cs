using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_system.Models;
using task_system.Repositories.Interfaces;

namespace task_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            List<User> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            User user = await _userRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            User createdUser = await _userRepository.Create(user);

            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update([FromBody] User user, int id)
        {
            if (user == null)
            {
                return NotFound();
            }

            user.Id = id;
            User updatedUser = await _userRepository.Update(user, id);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            bool deletedUser = await _userRepository.Delete(id);
            return Ok(deletedUser);
        }
    }
}
