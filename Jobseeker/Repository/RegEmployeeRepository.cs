using Jobseeker.Data;
using Jobseeker.Model;
using Microsoft.EntityFrameworkCore;

namespace Jobseeker.Repository
{
    public class RegEmployeeRepository: IRegEmployeeRepository
    {
        private readonly JobContext _context;
        public RegEmployeeRepository(JobContext context)
        {
            _context = context;
        }
        public async Task<SelectedEmployeeModel> AddRegEmployeeAsync(SelectedEmployeeModel employee)
        {
            var emp = new SelectedEmployeeModel()
            {
                EmployeeId = employee.EmployeeId,
                EmployeeDescription = employee.EmployeeDescription,
                EmployeeName = employee.EmployeeName,
                EmployeeEmail = employee.EmployeeEmail,
                Resume = employee.Resume,
                companyid=employee.companyid,
                jobid=employee.jobid,
            };
            _context.Add(emp);
            await _context.SaveChangesAsync();
            return emp;
        }
        public async Task<List<SelectedEmployeeModel>> getEmployeewithidAsync(int id)
        {
            return _context.regEmployees
                .Where(re => re.companyid == id)
                .ToList();
        }
        public async Task<List<SelectedEmployeeModel>> getJobwithidAsync(int id)
        {
            return _context.regEmployees
                .Where(re => re.EmployeeId == id)
                .ToList();
        }
    }
}
