using AF.Application.Contracts;
using AF.Application.DTO_s.Input;
using AF.Application.DTO_s.Output;
using AF.Application.Models;
using AF.Domain.Entities;
using AF.Domain.Interfaces;
using AF.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AF.Infrastructure.Repos
{
    public class UserRepository : GenericRepository<User>, IUserRepository, IUser {

        //TODO: RefreshToken yet to be implemented!!! + control + Cancellation token? in database? 

        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration configuration;

        public UserRepository(AppDbContext appDbContext, IConfiguration configuration) : base(appDbContext) 
        {
            this._appDbContext = appDbContext;
            this.configuration = configuration;
        }

        // Fancy DRY code
        private async Task<User> FindUserByEmail(string email) =>
           await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO) {
            var getUser = await FindUserByEmail(loginDTO.Email!);
            if (getUser == null) return new LoginResponse(false, 0, "User not found, sorry.");

            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginDTO.Password, getUser.Password);
            if (checkPassword)
                return new LoginResponse(true, getUser.Id, "Login succesfully", GenerateJWTToken(getUser));
            else
                return new LoginResponse(false, 0, "Invalid credentials");
        }

        public async Task<RegistrationResponse> RegisterUserAsync(RegistrationDTO registerUserDTO) {

            var getUser = await FindUserByEmail(registerUserDTO.Email!);
            if (getUser != null)
                return new RegistrationResponse(false, "User already exist.");

            //controleer de usertype en voeg dan bij de context de tenant of Lessor toe!
            //ander soort gegevens worden doorgegeven om dan de tenant ofwel de lessor aan te maken
            //TODO:

            User user;

            switch (registerUserDTO.UserType.ToLower())
            {
                case "tenant":
                    user = new Tenant
                    {
                        FirstName = registerUserDTO.FirstName,
                        LastName = registerUserDTO.LastName,
                        Email = registerUserDTO.Email,
                        Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password),
                        PhoneNumber = registerUserDTO.PhoneNumber,
                        StudioName = registerUserDTO.StudioName
                    };
                    break;

                case "lessor":
                    user = new Lessor
                    {
                        FirstName = registerUserDTO.FirstName,
                        LastName = registerUserDTO.LastName,
                        Email = registerUserDTO.Email,
                        Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password),
                        PhoneNumber = registerUserDTO.PhoneNumber,
                        BtwNr = registerUserDTO.BtwNr
                    };
                    break;

                default:
                    return new RegistrationResponse(false, "UserType doesn't exist");
            }

            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return new RegistrationResponse(true, "Registration completed");
        }

        private string GenerateJWTToken(User user) {

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userClaims = new[]{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.FirstName!),
                new Claim(ClaimTypes.Name, user.LastName!),
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


        public async Task<User> GetUserByIdAsync(int id)
        {
            var dbEntity = await GetByIdAsync(id);

            switch (dbEntity.GetType().Name.ToLower())
            {
                case "tenant":
                    return await _appDbContext.Tenants.Include(b => b.Bookings).FirstOrDefaultAsync(t => t.Id == id);
                case "lessor":
                    return await _appDbContext.Lessors.Include(c => c.Cars).FirstOrDefaultAsync(l => l.Id == id);
                default:
                    throw new ArgumentException("This type of user doesn't exist");
            }
        }
    }
}
