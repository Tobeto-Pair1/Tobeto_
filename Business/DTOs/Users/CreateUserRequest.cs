using Business.DTOs.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Users;

public class CreateUserRequest
{

  //  public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
   // public DateTime BirthDate { get; set; }
   // public string AboutMe { get; set; }
    //public Guid CountryId { get; set; }	   
    //public Guid CityId { get; set; }	   
    //public Guid TownId { get; set; }	   
    //public string Description { get; set; }
    //public bool? RememberMe { get; set; }


}

