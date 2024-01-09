using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Certificate
{
    public class GetListCertificateResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
    }
}
