using BklyOnboardingAPI.Application.Contracts.DTOs;
using System.Threading.Tasks;

namespace BklyOnboardingAPI.Application.Contracts.Interfaces
{
    public interface IOnboardingRepository
    {
        Task<bool> SendMail(SendOnboardingEmailDto emailDto);
    }
}
