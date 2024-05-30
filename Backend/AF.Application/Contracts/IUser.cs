using AF.Application.DTO_s.Input;
using AF.Application.DTO_s.Output;

namespace AF.Application.Contracts
{
    public interface IUser {

        Task<RegistrationResponse> RegisterUserAsync(RegistrationDTO registrationDTO);
        Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO);
    }
}
