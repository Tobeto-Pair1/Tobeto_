using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.UserEducations
{
    public class GetListUserEducationResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string EducationType { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime GraduationDate { get; set; }
    }
}
