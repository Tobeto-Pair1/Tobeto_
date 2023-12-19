using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class Homework:Entity<int>
	{
		public bool HomeWorkIsSend { get; set; }
		public string InstructorDescription { get; set; }
		public string StudentDescription { get; set; }
		public DateTime LastDate { get; set; }
		public string HomeworkTaskFile { get; set; }

		public virtual Program Program { get; set; } 
    }
}

