using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses;

public class CreatedEducationResponse
{
    public int Id { get; set; }
    public string EducationType { get; set; }
    public string University { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime GraduationDate { get; set; }
}
