using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Jobseeker.Model
{
    public class selectedemployeesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeEmail { get; set; }
        [Required]
        public byte[] Resume { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int jobid { get; set; }
        [Required]
        public int companyid { get; set; }
    }
}
