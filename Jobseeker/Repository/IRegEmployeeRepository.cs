using Jobseeker.Data;
using Jobseeker.Model;

namespace Jobseeker.Repository
{
    public interface IRegEmployeeRepository
    {
        Task<SelectedEmployeeModel> AddRegEmployeeAsync(SelectedEmployeeModel employee);
        Task<List<SelectedEmployeeModel>> getEmployeewithidAsync(int id);
        Task<List<SelectedEmployeeModel>> getJobwithidAsync(int id);
    }
}