using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Login;

public class LoginRequestDto
{
   public string UserNameOrEmail { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; } 



}
