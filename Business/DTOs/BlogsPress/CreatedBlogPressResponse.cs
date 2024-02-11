using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.BlogsPress;

public class CreatedBlogPressResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}
