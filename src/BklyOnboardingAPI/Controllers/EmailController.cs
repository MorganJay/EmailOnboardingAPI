using BklyOnboardingAPI.Application.Contracts.DTOs;
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
        public EmailController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        /// <summary>
        ///  Send a formatted email to web and mobile users during onboarding
        /// </summary>
        /// <returns></returns>
        [HttpPost("onboarding")]
        public async Task<IActionResult> SendOnboardingMail(SendOnboardingEmailDto emailDto)
        {
            return ApiOk(emailDto);
        }
    }
}
