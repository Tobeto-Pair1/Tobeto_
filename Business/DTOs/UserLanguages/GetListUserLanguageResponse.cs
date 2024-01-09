using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.UserLanguages
{
    public class GetListUserLanguageResponse
    {
        public Guid Id { get; set; }
        public Guid ForeignLanguageId { get; set; }
        public string ForeignLanguageName { get; set; }
        public Guid ForeignLanguageLevelId { get; set; }
        public string ForeignLanguageLevelName { get; set; }
    }
}
