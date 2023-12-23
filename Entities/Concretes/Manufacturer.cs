using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class Manufacturer:Entity<Guid>
	{
		public string Name { get; set; }
		public virtual ICollection<Course> Courses { get;}
	}
}

