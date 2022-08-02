using BklyOnboardingAPI.Domain.Entities;
using System.Threading.Tasks;

namespace BklyOnboardingAPI.Application.Contracts.Interfaces
{
    public interface IEmailTemplateRepository
    {
        Task<EmailTemplate> GetTemplate(int id);
    }
}
