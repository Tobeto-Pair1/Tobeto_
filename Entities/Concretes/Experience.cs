using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Experience : Entity<int>
{

    public int UserId { get; set; }
    public string Name { get; set; }
    public string Position { get; set;}
    public string Sector { get; set;}
     
     public Address Address { get; set; } 
    



}
