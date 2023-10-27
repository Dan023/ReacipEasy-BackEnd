using Microsoft.AspNetCore.Mvc;
using ReacipEasy.Models;
using ReacipEasy.Repositories;

namespace ReacipEasy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UsersRepository _usersRepository;
        public UsersController(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _usersRepository.GetAll();

            if (users != null && users.Any())
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _usersRepository.GetById(id: id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            await _usersRepository.Create(user);
            return CreatedAtAction(actionName: nameof(GetAllUsers), routeValues: new { id = user.Id }, value: user);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateUser(string id, UserModel user)
        {
            var existingUser = await _usersRepository.GetById(id: id);

            if (existingUser is null)
            {
                return BadRequest();
            }

            await _usersRepository.Update(user, id);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var existingUser = await _usersRepository.GetById(id: id);

            if (existingUser is null)
            {
                return BadRequest();
            }

            await _usersRepository.Delete(id: id);

            return NoContent();
        }
    }
}