using MicrosoftIdentity.Dtos;
using static MicrosoftIdentity.Dtos.ServiceResponses;

namespace MicrosoftIdentity.Services
{
    public interface IAccountServices
    {
        Task<GeneralResponse> CreateAccount(RegistrationDtos userDTO);
        Task<LoginResponse> LoginAccount(LoginDto loginDTO);
    }
}
