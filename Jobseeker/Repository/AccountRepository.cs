using Jobseeker.Data;
using Jobseeker.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jobseeker.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<user> usermanager;
        private readonly SignInManager<user> loginmanager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration conf;
        private readonly JobContext _context;

        public AccountRepository(UserManager<user> usermanager, SignInManager<user> loginmanager, RoleManager<IdentityRole> roleManager, IConfiguration conf, JobContext context)
        {
            this.usermanager = usermanager;
            this.loginmanager = loginmanager;
            this.roleManager = roleManager;
            this.conf = conf;
            _context = context;
        }
        public async Task<IdentityResult> CompanySignUpAsync(CompanySignupModel model)
        {
            var userExist = await usermanager.FindByEmailAsync(model.Email);
            if (userExist != null)
            {
                return null;
            }
            var account = new user()
            {
                Email = model.Email,
                Name = model.Name,
                UserName = model.Email,
                Address=model.Address,
                mobilenumber=model.Mobilenumber,
                userrole= "Company"
            };
            var result= await usermanager.CreateAsync(account,model.Password);
            if (!await roleManager.RoleExistsAsync("Company"))
            {
                var role = new IdentityRole { Name = "Company" };
                await roleManager.CreateAsync(role);
            }
            if (result.Succeeded)
            {
                // Assign the desired role to the user
                var roleName = "Company"; // Replace with the actual role name
                await usermanager.AddToRoleAsync(account, roleName);
            }
            return result;
        }
        public async Task<IdentityResult> EmployeeSignUpAsync(UserSignupModel model)
        {
            var userExist = await usermanager.FindByEmailAsync(model.Email);
            if (userExist != null)
            {
                return null;
            }
            var account = new user()
            {
                Email = model.Email,
                Name = model.Name,
                UserName = model.Email,
                Address = model.Address,
                mobilenumber = model.Mobilenumber,
                userrole = "Employee"
            };
            var result = await usermanager.CreateAsync(account, model.Password);
            if (!await roleManager.RoleExistsAsync("Employee"))
            {
                var role = new IdentityRole { Name = "Employee" };
                await roleManager.CreateAsync(role);
            }
            if (result.Succeeded)
            {
                // Assign the desired role to the user
                var roleName = "Employee"; // Replace with the actual role name
                await usermanager.AddToRoleAsync(account, roleName);
            }
            return result;
        }
        public async Task<Logindata> loginAsync(Login model)
        {
            var result = await loginmanager.PasswordSignInAsync(model.Email, model.Password,false,false);
            if (!result.Succeeded)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (user == null)
            {
                return null;
            }
            
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,model.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var authSignkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(conf["JWT:Secret"]));
            var token = new JwtSecurityToken(
            issuer: conf["JWT:ValidIssuer"],
            audience: conf["JWT:ValidAudience"],
            expires: DateTime.Now.AddDays(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSignkey, SecurityAlgorithms.HmacSha256Signature)
            );

            //return new JwtSecurityTokenHandler().WriteToken(token);
            Logindata data = new Logindata()
            {
                Username= user.UserName,
                Role=user.userrole,
                token= new JwtSecurityTokenHandler().WriteToken(token)
        };
            return data;

        }
    }
}
