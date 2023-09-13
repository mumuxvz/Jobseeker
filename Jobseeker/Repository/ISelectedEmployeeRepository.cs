using Jobseeker.Model;

namespace Jobseeker.Repository
{
    public interface ISelectedEmployeeRepository
    {
        Task<int> PostSelectedEmployee(selectedemployeesModel model);
    }
}