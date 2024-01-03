﻿using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Country : Entity<Guid>
{
    public string? Name { get; set; }
    public virtual List<City> Cities { get; set; }
}
