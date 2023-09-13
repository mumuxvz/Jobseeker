using Jobseeker.Data;
using Jobseeker.Model;

namespace Jobseeker.Repository
{
    public interface IJobRepository
    {
        Task<List<JobModel>> getallJobAsync();
        Task<int> PostJobAsync(JobModel model);
        Task<JobModel> GetJobByIdsAsync(int id);
        Task<Job> UpdateJobAsync(int id, JobModel model);
        Task<int> DeleteJobAsync(int id);
    }
}