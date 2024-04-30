using System.ComponentModel.DataAnnotations;

namespace MicrosoftIdentity.Dtos.PersonalInfoDto
{
    public class AddPersonalInfoDto
    {
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }

        public string? Title { get; set; }

        public string? Category { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string? PhoneNumber { get; set; }

        public string? Language { get; set; }

        public string? Proficiency { get; set; }

        public string? Summary { get; set; }
    }
}
