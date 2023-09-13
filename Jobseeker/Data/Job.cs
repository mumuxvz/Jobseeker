namespace Jobseeker.Data
{
    public class Job
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirment { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        
    }
}
