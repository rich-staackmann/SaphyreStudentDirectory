using SaphyreStudentDirectory.Domain.Models;

namespace SaphyreStudentDirectory.DAL.Repositories
{
    public interface IStudentRepository
    {
        public Task<List<Student>?> GetStudentsAsync();
        public Task<Student?> GetStudentByIdAsync(int id);
        public Task UpateStudentAsync(int id, Student student);
        public Task<int> CreateStudentAsync(Student student);
        public Task RemoveStudentAsync(int id);
    }
}
