using InventorySystem.Core.Application.DTO;
using InventorySystem.Core.Domain.Settings;
using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Core.Application.Interface.Services;

namespace InventorySystem.Infrastructured.Shared.Services
{
    public class EmailServices: IEmailService
    {
        private MailSettings _mailSettings { get; }
        public EmailServices(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;

        }
        public async Task SendEmailAsync(EmailRequest request)
        {
            try
            {
                // create message
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.EmailFrom);
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
