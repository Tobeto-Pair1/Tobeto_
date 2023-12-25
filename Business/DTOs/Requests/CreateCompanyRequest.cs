using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests
{
    public class CreateCompanyRequest
    {
        public string Name { get; set; }

        public Guid ExperienceId { get; set; }
    }
}
