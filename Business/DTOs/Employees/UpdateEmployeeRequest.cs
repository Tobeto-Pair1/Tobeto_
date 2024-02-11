using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Employees;

public class UpdateEmployeeRequest
{
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    //public string UserId { get; set; }
}
