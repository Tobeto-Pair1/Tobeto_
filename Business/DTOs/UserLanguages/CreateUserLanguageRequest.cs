using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.UserLanguages
{
    public class CreateUserLanguageRequest
    {
        public string LanguageName { get; set; }
        public string LanguageLevelName { get; set; }
        public Guid Id { get; set; }
    }
}
