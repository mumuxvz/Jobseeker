using Jobseeker.Data;
using Jobseeker.Model;
using Jobseeker.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jobseeker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository repo;
        private readonly JobContext context;
        public AccountController(IAccountRepository repo, JobContext context)
        {
            this.repo = repo;
            this.context = context;
        }
        [HttpPost("SignupCompany")]
        public async Task<IActionResult> SignupComp([FromBody] CompanySignupModel model)
        { 
            var result=await repo.CompanySignUpAsync(model);
            if (result.Succeeded)
            {
                var company = new Company()
                {
                    Name = model.Name,
                    Description = model.Name,
                    email = model.Email,
                    phone = model.Mobilenumber,
                    Address = model.Address,
                };
                context.Company.Add(company);
                await context.SaveChangesAsync();   
                return Ok(result.Succeeded);
            }
            return BadRequest();
            
        }
        [HttpPost("SignupEmployee")]
        public async Task<IActionResult> SignupEmp([FromBody] UserSignupModel model)
        {
            var result = await repo.EmployeeSignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return BadRequest();

        }
        [HttpPost("login")]
        public async Task<IActionResult> loginapi([FromBody] Login model)
        {
            var result = await repo.loginAsync(model);
            if (string.IsNullOrEmpty(result.token))
            {
                return Unauthorized();
            }
            
            return Ok(result);

        }
    }
}
