using Jobseeker.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobseeker.Model
{
    public class SelectedEmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeDescription { get; set; }
        [Required]
        [EmailAddress]
        public string EmployeeEmail { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public byte[] Resume { get; set; }
        [Required]
        public int companyid { get; set; }
        [Required]
        public int jobid { get; set; }
    }
}
