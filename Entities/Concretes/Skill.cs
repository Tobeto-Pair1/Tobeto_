﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Skill : Entity<int>
{

    public int UserId { get; set; }
    public int SkillName { get; set; }


}
