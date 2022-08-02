using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BklyOnboardingAPI.Domain.Entities
{
    [Table("tblEmailTemplate")]
    public class EmailTemplate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FromEmail { get; set; }

        [Required]
        public string FromName { get; set; }

        [Required]

        public string Subject { get; set; }

        [Required]
        public string Template { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }
    }
}
