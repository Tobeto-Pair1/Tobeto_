using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.UserLanguages
{
    public class DeleteUserLanguageRequest
    {
        public string Name { get; set; }
        public string Level { get; set; }
    }
}
