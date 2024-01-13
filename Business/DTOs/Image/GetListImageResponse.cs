using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Image
{
    public class GetListImageResponse
    {

        public Guid UserId { get; set; }
        public string? ImageUrl { get; set; }
    }

}
