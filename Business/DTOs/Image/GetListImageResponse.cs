using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Image;

public class GetListImageResponse
{
    public string FileName { get; set; }
    public string FileUrl { get; set; }
    public string Description { get; set; }
}
