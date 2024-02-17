using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.ContactInformations
{
    public class GetListContactInformationResponse
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string TaxDepartment { get; set; }
        public string TaxNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
