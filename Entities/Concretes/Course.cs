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
    public Guid CourseTypeId { get; set; }

    public virtual ICollection<CourseProgram> CoursePrograms { get; set; }
    public virtual AboutOfCourse AboutOfCourse { get; set; }
    public virtual CourseType CourseType { get; set; }
}

