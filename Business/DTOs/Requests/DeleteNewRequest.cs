namespace Business.DTOs.Requests
{
    public class DeleteNewRequest
    {
        public string Title { get; set; }
        public string Label { get; set; }
        public Guid NotificationId { get; set; }
    }
}
