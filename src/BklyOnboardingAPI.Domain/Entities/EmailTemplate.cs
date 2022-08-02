using System.ComponentModel.DataAnnotations.Schema;

namespace BklyOnboardingAPI.Domain.Entities
{
    [Table("tblEmailTemplate")]
    public class EmailTemplate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Template { get; set; }
    }
}
