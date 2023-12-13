using MVCCoreSendEmail.Models;
using MimeKit;
using Microsoft.Extensions.Options;

using MailKit.Net.Smtp;

namespace MVCCoreSendEmail.Services
{
    public class EmailService : IEmailService
    {
        EmailSettings _settings;
        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }
        public void SendEmail(EmailModel email)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress emailfrom = new MailboxAddress(_settings.Name, _settings.EmailId);
            MailboxAddress emailto = new MailboxAddress(email.ToName, email.ToEmail);
            message.From.Add(emailfrom);
            message.To.Add(emailto);
            message.Subject = email.Subject;
            BodyBuilder b = new BodyBuilder();
            b.TextBody=email.Body;
            message.Body = b.ToMessageBody();
            SmtpClient client = new SmtpClient();
            client.Connect(_settings.Host, _settings.Port, _settings.UseSSL);
            client.Authenticate(_settings.EmailId ,_settings.Password);
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();



        }
    }

}
