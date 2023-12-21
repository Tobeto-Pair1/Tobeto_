using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class SynchronLesson:Entity<Guid>
	{

        public DateTime DurationTime { get; set; }  //total süre
        public DateTime TimeSpent { get; set; }  //geçirilen süre
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid InstructorId { get; set; }

        // query yazılıp ders ile ilgili olan hocalar çekilecek comboboxdan aralarından seçim yaptırılacak**
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual CourseType CourseType { get; set; }
	}
}

