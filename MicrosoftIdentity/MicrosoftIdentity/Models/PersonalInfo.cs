using System.ComponentModel.DataAnnotations;

namespace MicrosoftIdentity.Models
{
    public class PersonalInfo
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Language { get; set; }

        public string Proficiency { get; set; }

        public string Summary { get; set; }

        // Foreign key
        public string UserId { get; set; }

        // Navigation property
        public ApplicationUser User { get; set; }
    
}
}
