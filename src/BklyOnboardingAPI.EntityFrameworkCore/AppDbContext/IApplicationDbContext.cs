using BklyOnboardingAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BklyOnboardingAPI.EntityFrameworkCore.AppDbContext
{
    public interface IApplicationDbContext
    {
        DbSet<EmailTemplate> EmailTemplates { get; set; }
       
    }
}