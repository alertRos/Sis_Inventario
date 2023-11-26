using MailKit.Net.Smtp;
using MimeKit;
using SisInventario.Dto.Email;
using SisInventario.Interface;
using SisInventario.Settings;

namespace SisInventario.Services
{
    public class EmailService: IEmailService
    {
        private MailSettings mailSettings { get; }
        public async Task SendEmailAsync(EmailRequest emailRequest)
        {
            try
            {
                MimeMessage email = new();
                email.Sender = MailboxAddress.Parse(mailSettings.DisplayName + " <" + mailSettings.EmailFrom + " >");
                email.To.Add(MailboxAddress.Parse(emailRequest.To));
                email.Subject = emailRequest.Subject;
                BodyBuilder bodyBuilder = new();
                bodyBuilder.HtmlBody = emailRequest.Body;
                email.Body = bodyBuilder.ToMessageBody();
                using SmtpClient smtpClient = new();
                smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtpClient.Connect(mailSettings.SmtpHost, mailSettings.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                smtpClient.Authenticate(mailSettings.SmtpUser, mailSettings.SmtpPass);
                await smtpClient.SendAsync(email);
                smtpClient.Disconnect(true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
