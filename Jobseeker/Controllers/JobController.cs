using AutoMapper;
using Jobseeker.Data;
using Jobseeker.Model;
using Jobseeker.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jobseeker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository repo;

        public JobController(IJobRepository repo)
        {
            this.repo = repo;
        }
        [HttpPost("")]
        public async Task<IActionResult> PostJobs([FromBody] JobModel model)
        {

            var id = await repo.PostJobAsync(model);
            return Ok(id);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {

            var jobs = await repo.getallJobAsync();
            return Ok(jobs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getJobsbyId([FromRoute] int id)
        {

            var jobs = await repo.GetJobByIdsAsync(id);
            if (jobs == null)
            {
                return NotFound();
            }
            return Ok(jobs);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobs([FromBody] JobModel bookModel, [FromRoute] int id)
        {

            var dem = await repo.UpdateJobAsync(id, bookModel);
            return Ok(dem);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteJobs([FromRoute] int id)
        {

            var dem = await repo.DeleteJobAsync(id);
            return Ok(dem);
        }


    }
}
