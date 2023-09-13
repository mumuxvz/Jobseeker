using AutoMapper;
using Jobseeker.Data;
using Jobseeker.Model;

namespace Jobseeker.Mapper
{
    public class ApplicationMapper:Profile
    {

        public ApplicationMapper() {
        
            CreateMap<Job,JobModel>().ReverseMap();
            CreateMap<Company, Companymodel>().ReverseMap();
            CreateMap<RegEmployee, SelectedEmployeeModel>().ReverseMap();
            CreateMap<SelectedEmployee, selectedemployeesModel>().ReverseMap();

        }  
    }
}
