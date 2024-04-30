using MicrosoftIdentity.Dtos.PersonalInfoDto;
using static MicrosoftIdentity.Dtos.ServiceResponses;

namespace MicrosoftIdentity.Services.PersonalInfoService
{
    public interface IPersonalServices
    {
        Task<(GeneralResponse, PersonalInfoDto)> AddPersonalInfo(string userId, AddPersonalInfoDto personalInfoDto);
        Task<(GeneralResponse, List<PersonalInfoDto>)> GetPersonalInfos(string userId);
        Task<(GeneralResponse, PersonalInfoDto)> UpdatePersonalInfo(int personalInfoId, UpdatePersonalInfoDto personalInfoDto);
        Task<GeneralResponse> DeletePersonalInfo(int personalInfoId);
        Task<GeneralResponse> DeleteAllPersonalInfo(string userId);
    }
}
