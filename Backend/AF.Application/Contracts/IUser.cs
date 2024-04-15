using AF.Application.DTO;

namespace AF.Application.Contracts {
    public interface IUser {

        Task<RegistrationResponse> RegisterUserAsync(RegistrationDTO registrationDTO);
        Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO);
    }
}
