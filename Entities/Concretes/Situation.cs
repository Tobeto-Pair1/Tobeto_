using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Situation : Entity<int>
{

    public string Name { get; set; }

    public List<Situation> Situations { get; set; }


}
