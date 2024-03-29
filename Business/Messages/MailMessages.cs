using Business.DTOs.Auths;
using Core.Utilities.EmailSender;
using System.Text;

namespace Business.Messages;

public class MailMessages : IMailMessages
{
    private readonly IEmailService _emailService;

    public  MailMessages(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void sendRegisterEmail(UserForRegisterRequest userForRegisterRequest)
    {
        string message = $@"<p>Tobeto'ya Hoşgeldin!</p>";
        string htmlBody = $@"<h4>E-posta Adresinizi Doğrulayın</h4> {message}";
        _emailService.Send(to: userForRegisterRequest.Email, subject: "Kaydınızı Onaylayın",
            html: htmlBody);
    }
    public void SendPasswordResetMailAsync(string email, string userId, string resetToken)
    {
        StringBuilder mail = new();
        mail.AppendLine($"Merhaba <br> Eğer yeni şifre talebinde bulundaysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz. <br><strong><a target=\"_blank\" href=\"http://localhost:3000/update-password/{Uri.EscapeDataString(userId)}/{Uri.EscapeDataString(resetToken)}\"> Yeni şifre talebi için tıklayınız.. </a></strong><br><br><span style=\"font-size:12px;\">NOT : Eğer ki bu talep tarafınızdan gerçekleştirilmediyse bu maili ciddiye almayınız.");
        _emailService.Send(to: email, subject: "Şifre Yenileme Talebi", html: mail.ToString());
    }
}
