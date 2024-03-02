using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.UserLanguages;

public class CreateUserLanguageRequest
{
    public Guid ForeignLanguageId { get; set; }
    public Guid ForeignLanguageLevelId { get; set; }
    public Guid UserId { get; set; }
}
