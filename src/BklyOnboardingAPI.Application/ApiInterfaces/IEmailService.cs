using BklyOnboardingAPI.Domain.Entities;
using System.Threading.Tasks;

namespace BklyOnboardingAPI.Application.ApiInterfaces
{
    public interface IEmailService
    {
        Task<bool> Send(EmailTemplate emailTemplate, string toEmail, string toName);
    }
}