using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class AppUser : IdentityUser<Guid>
{
 
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public string IdentityNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    


}
