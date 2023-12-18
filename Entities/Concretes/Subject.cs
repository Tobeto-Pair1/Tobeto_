﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Subject : Entity<int>
{

    public string Name { get; set; }

    public ICollection<Subject> Subjects { get; set; }
}
