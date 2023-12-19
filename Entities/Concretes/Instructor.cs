﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Instructor : Entity<int>
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    
    public int UserId { get; set; }

}
