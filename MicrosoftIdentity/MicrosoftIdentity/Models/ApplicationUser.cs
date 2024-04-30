    using Microsoft.AspNetCore.Identity;

    namespace MicrosoftIdentity.Models
    {
        public class ApplicationUser :IdentityUser
        {
        public ApplicationUser()
        {
            PersonalInfos = new List<PersonalInfo>();
        }
        public string Name { get; set; }
            public string  Address { get; set; }

         public virtual ICollection<PersonalInfo> PersonalInfos { get; set; }
    }
    }
