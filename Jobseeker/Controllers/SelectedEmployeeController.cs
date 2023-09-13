using Jobseeker.Model;
using Jobseeker.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jobseeker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectedEmployeeController : ControllerBase
    {
        private readonly ISelectedEmployeeRepository repo;

        public SelectedEmployeeController(ISelectedEmployeeRepository repo)
        {
            this.repo = repo;
        }
        [HttpPost("")]
        public async Task<IActionResult> postemployeeselected([FromBody] selectedemployeesModel model)
        {
            var id = await repo.PostSelectedEmployee(model);
            return Ok(id);
        }
    }
}
