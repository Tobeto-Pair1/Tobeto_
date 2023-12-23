using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class Homework:Entity<Guid>
	{
        public Guid CourseId { get; set; }
        public Guid SynchronLessonId { get; set; }
		public string Name { get; set; }
		public DateTime LastDate { get; set; }
		public string HomeworkTaskFile { get; set; }
        public string HomeworkSentFile { get; set; }

        public virtual Course Course { get; set; }
        public virtual SynchronLesson SynchronLesson { get; set; }
    }
}

