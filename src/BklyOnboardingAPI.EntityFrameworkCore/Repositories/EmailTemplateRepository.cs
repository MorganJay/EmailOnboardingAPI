using BklyOnboardingAPI.Application.Contracts.Interfaces;
using BklyOnboardingAPI.Domain.Entities;
using BklyOnboardingAPI.Domain.Shared.Responses;
using BklyOnboardingAPI.EntityFrameworkCore.AppDbContext;
using System.Threading.Tasks;

namespace BklyOnboardingAPI.EntityFrameworkCore.Repositories
{
    public class EmailTemplateRepository : IEmailTemplateRepository
    {
        private readonly IApplicationDbContext _dbContext;
        public EmailTemplateRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<EmailTemplate> GetTemplate(int id)
        {
            var emailTemplate = await _dbContext.EmailTemplates.FindAsync(id);

            if (emailTemplate is null) throw new CustomException($"Email template not found for id {id}");

            return emailTemplate;
        }
    }
}
