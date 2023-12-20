using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses
{
    public class GetListUserLanguageResponse
    {
        public Guid Id { get; set; }
        public Guid ForeignLanguageId { get; set; }
        public Guid UserId { get; set; }
        public Guid LanguageLevelId { get; set; }

    }
}
