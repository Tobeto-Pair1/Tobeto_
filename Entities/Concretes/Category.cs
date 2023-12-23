using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class Category : Entity<Guid>
	{
        public string Name{ get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category Categories { get; set; }
        public  virtual ICollection<Course> Courses { get; set; }
    }
}

