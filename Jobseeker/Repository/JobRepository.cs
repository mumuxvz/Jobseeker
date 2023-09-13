using AutoMapper;
using Jobseeker.Data;
using Jobseeker.Model;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Jobseeker.Repository
{
    public class JobRepository: IJobRepository
    {
        private readonly JobContext _context;
        private readonly IMapper mapper;

        public JobRepository(JobContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<List<JobModel>> getallJobAsync()
        {
               var records=await _context.Job.ToListAsync();
            return mapper.Map<List<JobModel>>(records);
        }
        public async Task<int> PostJobAsync(JobModel model)
        {
            var jobs = new Job()
            {
                Title = model.Title,
                Description= model.Description,
                Requirment=model.Requirment,
                CompanyID=model.CompanyID,
            };
            _context.Job.Add(jobs);
            await _context.SaveChangesAsync();
            return jobs.JobID;

        }
        public async Task<JobModel> GetJobByIdsAsync(int id)
        {
     
            //return records;
            var job = await _context.Job.FindAsync(id);
            return mapper.Map<JobModel>(job);

        }
        public async Task<Job> UpdateJobAsync(int id, JobModel model)
        {
            /*var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                book.Title = model.Title;
                book.Description = model.Description;
                await _context.SaveChangesAsync();
            }*/
            var jobs = new Job()
            {
                JobID=model.JobID,
                Title = model.Title,
                Description = model.Description,
                Requirment = model.Requirment,
                CompanyID = model.CompanyID,
            };
            _context.Job.Update(jobs);
            await _context.SaveChangesAsync();

            return jobs;

        }
        public async Task<int> DeleteJobAsync(int id)
        {
            //var book = await _context.Books.Where(x => x.Id == id).FirstOrDefault();
            var Jobs = await _context.Job.Where(x => x.JobID == id).Select(x => new Job()
            {
                JobID = x.JobID,
                Description = x.Description,
                Requirment = x.Requirment,
                CompanyID = x.CompanyID,

            }).FirstOrDefaultAsync();
            _context.Job.Remove(Jobs);
            await _context.SaveChangesAsync();
            return Jobs.JobID;

        }
    }
}
