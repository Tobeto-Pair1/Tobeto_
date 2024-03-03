namespace Core.Utilities.EmailSender;

public interface IEmailService
{
    void Send(string to, string subject, string html, string from = null);
}