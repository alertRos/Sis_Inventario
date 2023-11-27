using SisInventario.Dto.Email;

namespace SisInventario.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
