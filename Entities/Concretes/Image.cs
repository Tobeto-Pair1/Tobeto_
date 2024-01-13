using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Image:Entity<Guid>
    {
        public string? ImageUrl { get; set; }
        public Guid UserId { get; set; }


        //user 
        //courses
        //Lessons
        public User User { get; set; }
    }
}
