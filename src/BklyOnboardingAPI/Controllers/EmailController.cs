using BklyOnboardingAPI.Application.Contracts.DTOs;
using BklyOnboardingAPI.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BklyOnboardingAPI.Controllers
{
    /// <summary>
    ///  Send emails to consumers
    /// </summary>
    public class EmailController : BaseController
    {
        private readonly IOnboardingRepository _onboardingRepository;
        public EmailController(IHttpContextAccessor contextAccessor, IOnboardingRepository onboardingRepository) : base(contextAccessor)
        {
            _onboardingRepository = onboardingRepository;
        }

        /// <summary>
        ///  Send a formatted email to web and mobile users during onboarding
        /// </summary>
        /// <returns></returns>
        [HttpPost("onboarding")]
        public async Task<IActionResult> SendOnboardingMail(SendOnboardingEmailDto emailDto)
        {
            if(!ModelState.IsValid) return ApiBad(ModelState);

            var success = await _onboardingRepository.SendMail(emailDto);

            return success ? ApiOk(success, "Email sent successfully") : ApiBad(message: "Sorry, we couldn't send that email right now");
        }
    }
}
