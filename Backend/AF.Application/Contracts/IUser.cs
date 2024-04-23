using AF.Application.DTO.Input;
using AF.Application.DTO.Output;

namespace AF.Application.Contracts
{
    public interface IUser {

        Task<RegistrationResponse> RegisterUserAsync(RegistrationDTO registrationDTO);
        Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO);
    }
}
