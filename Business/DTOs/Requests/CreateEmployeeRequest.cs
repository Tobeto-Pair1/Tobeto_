using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests
{
    public class CreateEmployeeRequest
    {
        public Guid DepartmentId { get; set; }
        public Guid UserId { get; set; }

    }
}
