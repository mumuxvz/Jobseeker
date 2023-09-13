using System.ComponentModel.DataAnnotations;

namespace Jobseeker.Model
{
    public class Companymodel
    {

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string email { get; set; }

        [Required]
        public string phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
