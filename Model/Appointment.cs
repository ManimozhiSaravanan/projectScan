using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAApp.Model
{
    [Table("Appointment")]
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Cat { get; set; }

        [Required]
        public string PName { get; set; }

        [Required]
        public int PAge { get; set; }

        [Required]
        public string PGender { get; set; }

        [Required]
        [EmailAddress]
        public string PEmail { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime AppDateTime { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
      public List<SampleDetail> SampleDetails { get; set; }
    }
}
