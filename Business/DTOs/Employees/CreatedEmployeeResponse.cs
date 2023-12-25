using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Employees
{
    public class CreatedEmployeeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Guid UserId { get; set; }
    }
}
