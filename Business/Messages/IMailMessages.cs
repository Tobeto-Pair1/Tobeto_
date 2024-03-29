using Business.DTOs.Auths;

namespace Business.Messages;

public interface IMailMessages
{
    void sendRegisterEmail(UserForRegisterRequest userForRegisterRequest);
    void SendPasswordResetMailAsync(string email, string userId, string resetToken);
}
