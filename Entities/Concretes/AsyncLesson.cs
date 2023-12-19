using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class AsyncLesson : Entity<int>
	{

        public string Name { get; set; }

        public DateTime DurationTime { get; set; }  //total süre
        public DateTime TimeSpent { get; set; }  //geçirilen süre

        public int CourseModuleId { get; set; }
        public CourseModule CourseModule { get; set; }

        public virtual CourseType CourseType { get; set; }
	}
}

