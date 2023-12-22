using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses;

public class CreatedAboutOfCourseResponse
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; }
    public string CourseName { get; set; }
    public string ManufacturerName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime SpentTime { get; set; }
}
