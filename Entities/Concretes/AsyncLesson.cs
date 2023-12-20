using System;
using Core.Entities;

namespace Entities.Concretes
{
    public class AsyncLesson : Entity<Guid>
    {

        public string Name { get; set; }
        public DateTime DurationTime { get; set; }  //total süre
        public DateTime TimeSpent { get; set; }  //geçirilen süre
        public Guid InstructorId { get; set; }

        public Guid CourseModuleId { get; set; }
        public ICollection<Instructor> Instructors{get;set;}
        public CourseModule CourseModule { get; set; }

        public virtual CourseType CourseType { get; set; }
	}
}

