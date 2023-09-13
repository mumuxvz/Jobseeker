using Jobseeker.Model;
using Microsoft.AspNetCore.Identity;

namespace Jobseeker.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CompanySignUpAsync(CompanySignupModel model);
        Task<Logindata> loginAsync(Login model);
        Task<IdentityResult> EmployeeSignUpAsync(UserSignupModel model);

    }
}