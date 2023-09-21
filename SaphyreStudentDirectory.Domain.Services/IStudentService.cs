using SaphyreStudentDirectory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphyreStudentDirectory.Domain.Services
{
    public interface IStudentService
    {
        public Task<List<Student>?> GetStudentsAsync();
        public Task<Student?> GetStudentByIdAsync(int id);
        public Task UpateStudentAsync(int id, Student student);
        public Task<int> CreateStudentAsync(Student student);
        public Task RemoveStudentAsync(int id);
    }
}
