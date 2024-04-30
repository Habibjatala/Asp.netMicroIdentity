using Microsoft.EntityFrameworkCore;
using MicrosoftIdentity.DataContext;
using MicrosoftIdentity.Dtos.PersonalInfoDto;
using MicrosoftIdentity.Models;
using System.Threading.Tasks;
using static MicrosoftIdentity.Dtos.ServiceResponses;

namespace MicrosoftIdentity.Services.PersonalInfoService
{
    public class PersonalServices : IPersonalServices
    {
        private readonly DBContext _context;

        public PersonalServices(DBContext context)
        {
            _context = context;
        }

        public async Task<(GeneralResponse, PersonalInfoDto)> AddPersonalInfo(string userId, AddPersonalInfoDto personalInfoDto)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                    return (new GeneralResponse(false, "User not found"), null);

                

                var personalInfo = new PersonalInfo
                {
                    UserId = userId,
                    FirstName = personalInfoDto.FirstName,
                    LastName = personalInfoDto.LastName,
                    Title = personalInfoDto.Title,
                    Category = personalInfoDto.Category,
                    Country = personalInfoDto.Country,
                    City = personalInfoDto.City,
                    PhoneNumber = personalInfoDto.PhoneNumber,
                    Language = personalInfoDto.Language,
                    Proficiency = personalInfoDto.Proficiency,
                    Summary = personalInfoDto.Summary
                   
                };

                _context.PersonalInfos.Add(personalInfo);
                await _context.SaveChangesAsync();

                var addedPersonalInfoDto = new PersonalInfoDto
                {
                    FirstName = personalInfo.FirstName,
                    LastName = personalInfo.LastName,
                    Title = personalInfo.Title,
                    Category = personalInfo.Category,
                    Country = personalInfo.Country,
                    City = personalInfo.City,
                    PhoneNumber = personalInfo.PhoneNumber,
                    Language = personalInfo.Language,
                    Proficiency = personalInfo.Proficiency,
                    Summary = personalInfo.Summary
                  
                };

                return (new GeneralResponse(true, "Personal info added successfully"), addedPersonalInfoDto);
            }
            catch (DbUpdateException)
            {
                // Handle database update error
                return (new GeneralResponse(false, "Error occurred while saving personal info"), null);
            }
        }

        public async Task<(GeneralResponse, List<PersonalInfoDto>)> GetPersonalInfos(string userId)
        {
            try
            {
                var personalInfos = await _context.PersonalInfos
                    .Where(pi => pi.UserId == userId)
                    .ToListAsync();

                if (personalInfos == null || !personalInfos.Any())
                {
                    return (new GeneralResponse(false, "No personal info found for the specified user"), null);
                }

                var personalInfoDtos = personalInfos.Select(MapToDto).ToList();
                return (new GeneralResponse(true, "Personal info retrieved successfully"), personalInfoDtos);
            }
            catch (Exception ex)
            {
                // Log the exception
                return (new GeneralResponse(false, "An error occurred while processing the request"), null);
            }
        }

        private PersonalInfoDto MapToDto(PersonalInfo personalInfo)
        {
            return new PersonalInfoDto
            {
                FirstName = personalInfo.FirstName,
                LastName = personalInfo.LastName,
                Title = personalInfo.Title,
                Category = personalInfo.Category,
                Country = personalInfo.Country,
                City = personalInfo.City,
                PhoneNumber = personalInfo.PhoneNumber,
                Language = personalInfo.Language,
                Proficiency = personalInfo.Proficiency,
                Summary = personalInfo.Summary
            };
        }

        public async Task<(GeneralResponse, PersonalInfoDto)> UpdatePersonalInfo(int personalInfoId, UpdatePersonalInfoDto personalInfoDto)
        {
            try
            {
              
                var personalInfo = await _context.PersonalInfos.FindAsync(personalInfoId);

                
                if (personalInfo == null)
                {
                    return (new GeneralResponse(false, "Personal info not found"), null);
                }

                
                personalInfo.FirstName = personalInfoDto.FirstName;
                personalInfo.LastName = personalInfoDto.LastName;
                personalInfo.Title = personalInfoDto.Title;
                personalInfo.Category = personalInfoDto.Category;
                personalInfo.Country = personalInfoDto.Country;
                personalInfo.City = personalInfoDto.City;
                personalInfo.PhoneNumber = personalInfoDto.PhoneNumber;
                personalInfo.Language = personalInfoDto.Language;
                personalInfo.Proficiency = personalInfoDto.Proficiency;
                personalInfo.Summary = personalInfoDto.Summary;

          
                _context.PersonalInfos.Update(personalInfo);
                await _context.SaveChangesAsync();

              
                var updatedPersonalInfoDto = MapToDto(personalInfo);

            
                return (new GeneralResponse(true, "Personal info updated successfully"), updatedPersonalInfoDto);
            }
            catch (Exception ex)
            {
              
                return (new GeneralResponse(false, "An error occurred while updating personal info"), null);
            }
        }


        public async Task<GeneralResponse> DeletePersonalInfo(int personalInfoId)
        {
            try
            {
                var personalInfo = await _context.PersonalInfos.FindAsync(personalInfoId);
                if (personalInfo == null)
                {
                    return new GeneralResponse(false, "Personal info not found");
                }

                _context.PersonalInfos.Remove(personalInfo);
                await _context.SaveChangesAsync();

                return new GeneralResponse(true, "Personal info deleted successfully");
            }
            catch (Exception)
            {
          
                return new GeneralResponse(false, "An error occurred while deleting personal info");
            }
        }


        public async Task<GeneralResponse> DeleteAllPersonalInfo(string userId)
        {
            try
            {
                var personalInfos = await _context.PersonalInfos.Where(pi => pi.UserId == userId).ToListAsync();
                if (personalInfos == null || personalInfos.Count == 0)
                {
                    return new GeneralResponse(false, "No personal info found for the specified user");
                }

                _context.PersonalInfos.RemoveRange(personalInfos);
                await _context.SaveChangesAsync();

                return new GeneralResponse(true, "All personal info deleted successfully");
            }
            catch (Exception)
            {
            
                return new GeneralResponse(false, "An error occurred while deleting personal info");
            }
        }


    }


}

