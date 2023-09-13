using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobseeker.Data
{
    public class RegEmployee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDescription { get; set; }
        public string EmployeeEmail { get; set; }
        public byte[] Resume { get; set; }
        public int EmployeeId { get; set; }
        public int jobid { get; set; }
        public int companyid { get; set; }
       
    }

}
