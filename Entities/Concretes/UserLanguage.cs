using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class UserLanguage : Entity<Guid>
{

    public int LanguageId { get; set; }
    public int UserId { get; set; }

    public User User { get; set; }
    public ForeignLanguage ForeignLanguage { get; set; }




}
