using System;

namespace BklyOnboardingAPI.Domain.Shared.Responses
{
    public class CustomException : ApplicationException
    {
        public CustomException(string message) : base(message)
        {
        }
    }
}
