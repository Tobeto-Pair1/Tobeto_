using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Blogs;

public class CreatedBlogResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}
