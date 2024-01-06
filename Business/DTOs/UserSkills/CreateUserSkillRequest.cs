using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests
{
    public class CreateUserSkillRequest
    {
        public Guid SkillId { get; set; }
        public Guid Id { get; set; }

    }
}
