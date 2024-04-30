using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftIdentity.Dtos.PersonalInfoDto;
using MicrosoftIdentity.Migrations;
using MicrosoftIdentity.Services.PersonalInfoService;

namespace MicrosoftIdentity.Controllers.PContoller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly IPersonalServices _personalServices;

        public PersonalInfoController(IPersonalServices personalServices)
        {
            _personalServices = personalServices;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPersonalInfo(string userId, [FromBody] AddPersonalInfoDto personalInfoDto)
        {
            var (response, addedPersonalInfo) = await _personalServices.AddPersonalInfo(userId, personalInfoDto);

            if (!response.Flag)
            {
                return BadRequest(new { Success = false, Message = response.Message });
            }

            return Ok(new { Success = true, Message = response.Message, PersonalInfo = addedPersonalInfo });
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPersonalInfo(string userId)
        {
            var (response, personalInfoDtos) = await _personalServices.GetPersonalInfos(userId);

            if (!response.Flag)
            {
                return NotFound(response);
            }

            return Ok(new { Message = response, PersonalInfo = personalInfoDtos });
        }

        [HttpPut("{personalInfoId}")]
        public async Task<IActionResult> UpdatePersonalInfo(int personalInfoId, [FromBody] UpdatePersonalInfoDto personalInfoDto)
        {
            var (response, updatedPersonalInfo) = await _personalServices.UpdatePersonalInfo(personalInfoId, personalInfoDto);

            if (!response.Flag)
            {
                return BadRequest(new { Success = false, Message = response.Message });
            }

            return Ok(new { Success = true, Message = response.Message, PersonalInfo = updatedPersonalInfo });
        }


        [HttpDelete("{personalInfoId}")]
        public async Task<IActionResult> DeletePersonalInfo(int personalInfoId)
        {
            var response = await _personalServices.DeletePersonalInfo(personalInfoId);

            if (!response.Flag)
            {
                return BadRequest(new { Success = false, Message = response.Message });
            }

            return Ok(new { Success = true, Message = response.Message });
        }


        [HttpDelete("delete-all/{userId}")]
        public async Task<IActionResult> DeleteAllPersonalInfo(string userId)
        {
            var response = await _personalServices.DeleteAllPersonalInfo(userId);

            if (!response.Flag)
            {
                return BadRequest(new { Success = false, Message = response.Message });
            }

            return Ok(new { Success = true, Message = response.Message });
        }
    }
}
