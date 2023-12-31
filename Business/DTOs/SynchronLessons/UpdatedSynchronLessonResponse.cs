﻿namespace Business.DTOs.SynchronLessons
{
    public class UpdatedSynchronLessonResponse
    {

        public Guid Id { get; set; }
        public DateTime DurationTime { get; set; }
        public DateTime TimeSpent { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid InstructorId { get; set; }
    }
}
