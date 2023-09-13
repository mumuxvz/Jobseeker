namespace Jobseeker.Data
{
    public class SelectedEmployee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public byte[] Resume { get; set; }
        public int EmployeeId { get; set; }
        public int jobid { get; set; }
        public int companyid { get; set; }
    }
}
