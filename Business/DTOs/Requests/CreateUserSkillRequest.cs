using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests
{
    public class CreateUserSkillRequest
    {
        public Guid SkillName { get; set; }
        public Guid FirtName { get; set; }
        public Guid LastName { get; set; }
    }
}
