using AutoMapper;
using SaphyreStudentDirectory.Domain.Models;
using SaphyreStudentDirectory.Client.ViewModels;

namespace SaphyreStudentDirectory.Server
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Student, StudentVM>().ReverseMap();
        }
    }
}
