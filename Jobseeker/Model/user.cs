using Microsoft.AspNetCore.Identity;

namespace Jobseeker.Model
{
    public class user:IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string mobilenumber { get; set; }
        public string userrole { get; set; }
    }
}
