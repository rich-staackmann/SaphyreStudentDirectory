using Microsoft.EntityFrameworkCore;
using SaphyreStudentDirectory.Domain.Models;

namespace SaphyreStudentDirectory.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;

        public StudentRepository(StudentContext context)
        {
            _context = context;
        }
        public async Task<List<Student>?> GetStudentsAsync()
        {
            if (_context.Students == null)
            {
                return null;
            }
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            if (_context.Students == null)
            {
                return null;
            }

            return await _context.Students.FindAsync(id);
        }

        public async Task UpateStudentAsync(int id, Student student)
        {
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<int> CreateStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student.ID;
        }

        public async Task RemoveStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
