using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class Program:Entity<int>
	{
		public string Name { get; set; }

		public virtual ICollection<CourseProgram> CoursePrograms{ get;set;}
		public virtual ICollection <Homework> Homeworks {get;set;}
	}
}

