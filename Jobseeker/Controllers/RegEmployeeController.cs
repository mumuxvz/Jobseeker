using Jobseeker.Model;
using Jobseeker.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jobseeker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegEmployeeController : ControllerBase
    {
        private readonly IRegEmployeeRepository _regEmployeeRepository;

        public RegEmployeeController(IRegEmployeeRepository regEmployeeRepository)
        {
            _regEmployeeRepository = regEmployeeRepository;
        }
        [HttpPost("")]
        public async Task<IActionResult> PostRegEMployee([FromBody] SelectedEmployeeModel model)
        {

            var id = await _regEmployeeRepository.AddRegEmployeeAsync(model);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        { 
            var ans=await _regEmployeeRepository.getEmployeewithidAsync(id);
            return Ok(ans);
        }
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetempByempId(int id)
        {
            var ans = await _regEmployeeRepository.getJobwithidAsync(id);
            return Ok(ans);
        }
    }
}
