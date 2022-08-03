using BklyOnboardingAPI.Application.ApiInterfaces;
using BklyOnboardingAPI.Application.Contracts.DTOs;
using BklyOnboardingAPI.Application.Contracts.Interfaces;
using BklyOnboardingAPI.Domain.Shared.Helpers;
using System.Threading.Tasks;
using static BklyOnboardingAPI.Domain.Shared.Constants.Enums;

namespace BklyOnboardingAPI.EntityFrameworkCore.Repositories
{
    public class OnboardingRepository : IOnboardingRepository
    {
        private readonly IEmailService _emailService;
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        public OnboardingRepository(IEmailTemplateRepository emailTemplateRepository, IEmailService emailService)
        {
            _emailTemplateRepository = emailTemplateRepository;
            _emailService = emailService;
        }

        public async Task<bool> SendMail(SendOnboardingEmailDto emailDto)
        {
            var templateId = (int)(emailDto.ViaMobile ? EmailTemplate.MOBILE_ONBOARDING : EmailTemplate.WEB_ONBOARDING);

            var template = await _emailTemplateRepository.GetTemplate(templateId);

            var password = StringHelper.CreateRandomPassword(10);

            template.Template = template.Template.Replace("{FirstName}", emailDto.FullName.Split(" ")[0]).Replace("{FullName}", emailDto.FullName).Replace("{PhoneNumber}", emailDto.PhoneNumber).Replace("{Username}", emailDto.UserName).Replace("{Password}", password).Replace("{Passcode}", password);

            var recipientName = emailDto.ViaMobile ? emailDto.FullName : emailDto.UserName;
            var emailSent = await _emailService.Send(template, emailDto.Email, recipientName);

            return emailSent;
        }
    }
}
