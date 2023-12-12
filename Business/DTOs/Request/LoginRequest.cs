using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request;

public class LoginRequest
{


    public string EmailOrUserName { get; set; }
    public string Password { get; set; }


}
