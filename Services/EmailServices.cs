using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace BordoProject.Services
{
    public class EmailServices : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailServices(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            if (string.IsNullOrEmpty(to))
            {
                throw new ArgumentException("Recipient email address cannot be null or empty.", nameof(to));
            }
            var message = new MailMessage
            {
                From = new MailAddress("nurayseduvan1@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            message.To.Add(to);
            

            //using var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port)
            //{
            //    Credentials = new NetworkCredential(_emailSettings.FromEmail, _emailSettings.Password),
            //    EnableSsl = true
            //};
            using var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("nurayseduvan1@gmail.com", "Babam807033."),
                EnableSsl = true
            };
            await client.SendMailAsync(message);
        }
    }
}
