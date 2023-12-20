﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Course : Entity<Guid>
{
    public string Name { get; set; }
    public bool IsCourseType { get; set; }

    public AboutOfCourse AboutOfCourse { get; set; }
}

