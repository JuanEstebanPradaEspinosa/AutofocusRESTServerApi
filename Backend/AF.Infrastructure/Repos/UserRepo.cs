using AF.Application.Interfaces;
using AF.Application.DTO.Input;
using AF.Application.DTO.Output;
using AF.Infrastructure.Entities;
using AF.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AF.Infrastructure.Repos
{
    public class UserRepo : IUser {

        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration configuration;

        public UserRepo(AppDbContext appDbContext, IConfiguration configuration) {
            this._appDbContext = appDbContext;
            this.configuration = configuration;
        }

        // Fancy DRY code
        private async Task<User> FindUserByEmail(string email) =>
           await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO) {
            var getUser = await FindUserByEmail(loginDTO.Email!);
            if (getUser == null) return new LoginResponse(false, "User not found, sorry.");

            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginDTO.Password, getUser.Password);
            if (checkPassword)
                return new LoginResponse(true, "Login succesfully", GenerateJWTToken(getUser));
            else
                return new LoginResponse(false, "Invalid credentials");
        }

        public async Task<RegistrationResponse> RegisterUserAsync(RegistrationDTO registerUserDTO) {

            var getUser = await FindUserByEmail(registerUserDTO.Email!);
            if (getUser != null)
                return new RegistrationResponse(false, "User already exist.");

            _appDbContext.Users.Add(new User {
                Name = registerUserDTO.Name,
                LastName = registerUserDTO.LastName,
                Email = registerUserDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password),
                PhoneNumber = registerUserDTO.PhoneNumber,
                ProfilePicture = registerUserDTO.ProfilePicture
            });

            await _appDbContext.SaveChangesAsync();
            return new RegistrationResponse(true, "Registration completed");
        }

        private string GenerateJWTToken(User user) {

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userClaims = new[]{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Email, user.Email!),
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
