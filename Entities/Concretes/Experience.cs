using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Experience : Entity<int>
{

    public int UserId { get; set; }
    public string FirmName { get; set; }
    public string Position { get; set;}
    public string Sector { get; set;}
    public string City { get; set;}
    public string Distinct { get; set;}
    public string Street { get; set;}
    public string Description { get; set;}
    



}
