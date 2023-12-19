using System;
using System.Reflection;
using Core.Entities;

namespace Entities.Concretes
{
	public class AboutOfCourse:Entity<int>
	{



		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public DateTime SpentTime { get; set; }
	
        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }


		public Lesson Lesson { get; set; }
	
	}
}

