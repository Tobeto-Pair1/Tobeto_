using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Company
{
    public class GetListCompanyResponse
    {
        public string Name { get; set; }

        public Guid CompanyId { get; set; }

        public Guid ExperienceId { get; set; }


    }
}
