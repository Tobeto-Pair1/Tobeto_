using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Employees;

public class UpdateEmployeeRequest
{
    public Guid Id { get; set; }
    //public Guid DepartmentId { get; set; }
    //public Guid? ImageId { get; set; }
    public string DepartmentName { get; set; }
    public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
}
