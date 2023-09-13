using Jobseeker.Data;
using Jobseeker.Migrations;
using Jobseeker.Model;
using Microsoft.EntityFrameworkCore;

namespace Jobseeker.Repository
{
    public class SelectedEmployeeRepository: ISelectedEmployeeRepository
    {
        private readonly JobContext context;
        public SelectedEmployeeRepository(JobContext context)
        {
            this.context = context;
        }
        public async Task<int> PostSelectedEmployee(selectedemployeesModel model)
        {
            var emp = new SelectedEmployee()
            {

                EmployeeEmail = model.EmployeeEmail,
                EmployeeName = model.EmployeeName,
                Resume = model.Resume,
                jobid = model.jobid,
                EmployeeId = model.EmployeeId,
                companyid=model.companyid
            };
            context.selectedEmployees.Add(emp);
            await context.SaveChangesAsync();
            return emp.Id;

        }
    }
}
