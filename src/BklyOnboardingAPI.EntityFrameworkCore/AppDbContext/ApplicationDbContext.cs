using BklyOnboardingAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BklyOnboardingAPI.EntityFrameworkCore.AppDbContext
{
    public partial class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Bankly");
            }
        }

     
    }
}