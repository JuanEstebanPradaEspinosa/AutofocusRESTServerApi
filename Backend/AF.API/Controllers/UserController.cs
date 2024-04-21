using AF.Application.Contracts;
using AF.Application.DTO.Input;
using AF.Application.DTO.Output;
using AF.Domain.Entities;
using AF.Infrastructure.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IUser _user;
        private readonly IRepository<User> _userRepository;
        public UserController(IUser user, IRepository<User> repository) {
            this._user = user;
            this._userRepository = repository;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LogUserIn(LoginDTO loginDTO) {
            var result = await _user.LoginUserAsync(loginDTO);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterUserIn(RegistrationDTO registrationDTO) {
            var result = await _user.RegisterUserAsync(registrationDTO);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers() {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id) {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
