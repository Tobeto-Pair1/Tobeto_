namespace Business.DTOs.SynchronLessons
{
    public class DeleteSynchronLessonRequest
    {
        public DateTime DurationTime { get; set; }
        public DateTime TimeSpent { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
