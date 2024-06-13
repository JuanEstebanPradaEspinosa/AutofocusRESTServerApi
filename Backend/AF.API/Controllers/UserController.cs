using AF.Application;
using AF.Application.Contracts;
using AF.Application.DTO_s.Input;
using AF.Application.DTO_s.Output;
using AF.Application.Models;
using AF.Infrastructure.Repos;
using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IUser _user;
        private Manager _manager;
        private IMapper _mapper;

        public UserController(IUser user,Manager manager, IMapper mapper) {
            this._user = user;
            this._manager = manager;
            this._mapper = mapper;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> LogUserIn(LoginDTO loginDTO) {
            try
            {
                var result = await _user.LoginUserAsync(loginDTO);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }

        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterUserIn(RegistrationDTO registrationDTO) {
            try
            {
                var result = await _user.RegisterUserAsync(registrationDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }

        }

/*        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }*/

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRestnormalDTO>> GetUserById(int id)
        {
            try
            {
                var user = await _manager.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                UserRestnormalDTO userDTO;
                switch (user.GetType().Name.ToLower())
                {
                    case "tenantmodel":
                        userDTO = _mapper.Map<TenantRESToutputDTO>(user);
                        break;
                    case "lessormodel":
                        userDTO = _mapper.Map<LesserRESToutputDTO>(user);
                        break ;
                    default:
                        throw new ArgumentException("This type of user doesn't exist");
                }

                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveUserAsync(int userId)
        {
            try
            {
                await _manager.RemoveUserAsync(userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }
    }
}
