using SaphyreStudentDirectory.DAL.Repositories;
using SaphyreStudentDirectory.Domain.Models;

namespace SaphyreStudentDirectory.Domain.Services
{
    /*
     * I put this class in a Domain project to signify that it handles business logic.
     * Obviously there isn't much real logic here but only services in this project should contain it.
     */
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepositroy;

        public StudentService(IStudentRepository studentRepositroy)
        {
            _studentRepositroy = studentRepositroy;
        }
        public async Task<List<Student>?> GetStudentsAsync()
        {
            return await _studentRepositroy.GetStudentsAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _studentRepositroy.GetStudentByIdAsync(id);
        }

        public async Task UpateStudentAsync(int id, Student student)
        {
            await _studentRepositroy.UpateStudentAsync(id, student);
        }

        public async Task<int> CreateStudentAsync(Student student)
        {
            return await _studentRepositroy.CreateStudentAsync(student);
        }

        public async Task RemoveStudentAsync(int id)
        {
            await _studentRepositroy.RemoveStudentAsync(id);
        }
    }
}
