﻿    using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class UserSkill : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid SkillId  { get; set; }

    public virtual User User { get; set; }
    public  virtual Skill Skill { get; set; }
}
