using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request
{
    public class UpdateLanguageRequest
    {
        public string LanguageName { get; set; }
        public string LanguageLevel { get; set; }
    }
}
