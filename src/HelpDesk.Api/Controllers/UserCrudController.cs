using HelpDesk.Api.Repository.IRepository;
using HelpDesk.Domain.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCrudController : ControllerBase
    {
        private readonly IUserCrudRepository _repository;

        public UserCrudController(IUserCrudRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserCrudDTO>> GetUser(int userId)
        {
            var user = await _repository.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCrudDTO>>> GetAllUsers()
        {
            var users = await _repository.GetAllUsers();

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserCrudDTO>> CreateUser(UserCrudDTO user)
        {
            var createdUser = await _repository.CreateUser(user);

            return CreatedAtAction(nameof(GetUser), new { userId = createdUser.UserId }, createdUser);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserCrudDTO>> UpdateUser(int userId, UserCrudDTO user)
        {
            if (userId != user.UserId)
            {
                return BadRequest();
            }

            var existingUser = await _repository.GetUserById(userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            var updatedUser = await _repository.UpdateUser(user);

            return Ok(updatedUser);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var existingUser = await _repository.GetUserById(userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _repository.DeleteUser(userId);

            return NoContent();
        }
    }
}

