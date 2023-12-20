using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests;

public class CreateAboutOfCourseRequest
{
    public Guid CategoryId { get; set; }
    public Guid ManufacturerId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime SpentTime { get; set; }
}
