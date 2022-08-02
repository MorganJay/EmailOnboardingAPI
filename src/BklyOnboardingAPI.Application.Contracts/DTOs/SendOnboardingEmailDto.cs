using System.ComponentModel.DataAnnotations;

namespace BklyOnboardingAPI.Application.Contracts.DTOs
{
    public class SendOnboardingEmailDto
    {
        [Required]
        public bool ViaMobile { get; set; } = false;

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"0([7][0]|[89][01])\d{8}$", ErrorMessage = "Invalid Phone Number Format")]
        public string PhoneNumber { get; set; }

        public string UserName { get; set; } 
    }
}
