using BklyOnboardingAPI.Application.ApiInterfaces;
using BklyOnboardingAPI.Domain.Entities;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace BklyOnboardingAPI.Application.ApiServices
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Send(EmailTemplate emailTemplate, string toEmail, string toName)
        {
            var apiKey = _configuration["SendGrid:ApiKey"];
            var sender = _configuration["SendGrid:Sender"];

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(sender, emailTemplate.FromName);
            var subject = emailTemplate.Subject;
            var to = new EmailAddress(toEmail, toName);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, string.Empty, emailTemplate.Template);
            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode;
        }
    }
}
