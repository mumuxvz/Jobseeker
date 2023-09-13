using System.ComponentModel.DataAnnotations;
namespace Jobseeker.Model
{
    public class UserSignupModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mobilenumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
