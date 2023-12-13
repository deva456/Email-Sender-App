using MVCCoreSendEmail.Models;

namespace MVCCoreSendEmail.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailModel email);
    }
}
