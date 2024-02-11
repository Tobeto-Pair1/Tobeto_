using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class BlogPress : Entity<Guid>
{
    public string Title { get; set; }
    public string Text { get; set; }
}
