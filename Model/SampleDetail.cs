using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAApp.Model
{
    [Table (name:"SampleDetail")]
    public class SampleDetail
    {
        [Key]
        public int Id { get; set; }

        
        public int AppointmentId { get; set; }


        [Required]
        public string Sample { get; set; }

        [Required]
        public string Result { get; set; }
    }
}
