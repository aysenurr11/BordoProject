
using System.Net;
using System.Net.Mail;
using BordoProject.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BordoProject.Services
{
    public class EmailScheduler : BackgroundService
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EmailScheduler> _logger;
        //Arka planda çalışması için 
        public EmailScheduler(IServiceProvider serviceProvider, ILogger<EmailScheduler> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                var nextMonday = now.AddDays(((int)DayOfWeek.Monday - (int)now.DayOfWeek + 7) % 7);
                var timeToWait = nextMonday - now;

                _logger.LogInformation($"Next Monday scheduled for {nextMonday}. Waiting {timeToWait.TotalMinutes} minutes.");
                //Bir sonraki paartesiye  kadar bekler
                await Task.Delay(timeToWait, stoppingToken);

                try
                {
                    await SendEmailsAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while sending emails.");
                }

                await Task.Delay(TimeSpan.FromDays(7), stoppingToken); // e posta göndermek icin 1 hafta bekler
            }
        }

        private async Task SendEmailsAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var emailAddresses = context.Employees
     .Where(e => !string.IsNullOrEmpty(e.Email) && e.Email.Contains("@")) // Email formatını kontrol edin
     .Select(e => e.Email)
     .ToList();

                foreach (var email in emailAddresses)
                {
                    try
                    {
                        await emailService.SendEmailAsync(email, "Weekly Survey", "Linke tıklayınız: <a href='http://localhost:5167/Training/'>Survey Link</a>");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"An error occurred while sending email to {email}.");
                    }
                }
            }
        }

    }

}
