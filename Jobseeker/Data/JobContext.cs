using Jobseeker.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Jobseeker.Data
{
    public class JobContext:IdentityDbContext<user>
    {
        public JobContext(DbContextOptions<JobContext> options) : base(options)
        {

        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<SelectedEmployeeModel> regEmployees { get; set; }
        public DbSet<SelectedEmployee> selectedEmployees { get; set; }

    }
}
