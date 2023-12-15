using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class UserLanguage : Entity<int>
{

    public int LanguageId { get; set; }
    public int UserId { get; set; }
    public int LevelId { get; set; }




}
