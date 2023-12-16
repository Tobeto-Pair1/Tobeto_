using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses;

public class CreatedUserResponse
{

    public string IdentityNumber { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}
