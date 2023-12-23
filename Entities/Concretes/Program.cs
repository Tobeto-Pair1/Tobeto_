using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class Program:Entity<Guid>
	{
		public string Name { get; set; }

		public virtual ICollection<CourseProgram> CoursePrograms{ get;set;}
	}
}

