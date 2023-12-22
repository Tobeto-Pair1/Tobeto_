namespace Business.DTOs.Requests
{
    public class UpdateNewRequest
    {
        public string Title { get; set; }
        public string Label { get; set; }
        public Guid NotificationId { get; set; }
    }
}
