using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses
{
    public class DeletedEmployeeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepartmentId { get; set; }
        public Guid UserId { get; set; }
    }
}
