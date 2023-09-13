namespace Jobseeker.Data
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string Address { get; set; }
        public ICollection<Job> Jobs { get; set; }
        

    }
}
