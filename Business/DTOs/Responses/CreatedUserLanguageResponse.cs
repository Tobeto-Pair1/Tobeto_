using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses
{
    public class CreatedUserLanguageResponse
    {
        public string LanguageName { get; set; }
        public string LanguageLevelName { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string AboutMe { get; set; }
    }
}
