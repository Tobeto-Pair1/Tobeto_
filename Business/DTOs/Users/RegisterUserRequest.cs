using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Users;

public class RegisterUserRequest
{
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public string  Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }

}
