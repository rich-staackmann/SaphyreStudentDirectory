using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SaphyreStudentDirectory.DAL.Repositories;
using SaphyreStudentDirectory.Domain.Models;
using System.Data.Common;

namespace SaphyreStudentDirectory.Tests
{
    [TestClass]
    public class StudentRepoTests : IDisposable
    {
        private readonly DbConnection _connection;
        private readonly DbContextOptions<StudentContext> _contextOptions;

        public StudentRepoTests()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _contextOptions = new DbContextOptionsBuilder<StudentContext>()
                .UseSqlite(_connection)
                .Options;

            using var context = new StudentContext(_contextOptions);
            context.Database.EnsureCreated();

            context.AddRange(
                new Student()
                {
                    ID = 1,
                    Name = "Billy Bob Joe",
                    Address1 = "123 Fake Street",
                    City = "New York",
                    State = "NY",
                    PhoneNumber = "123-456-7890",
                    Age = 33
                },
                new Student()
                {
                    ID = 2,
                    Name = "Theresa May June",
                    Address1 = "123 Fake Street",
                    City = "New York",
                    State = "NY",
                    PhoneNumber = "123-456-7890",
                    Age = 33
                });
            context.SaveChanges();
        }

        StudentContext CreateContext() => new StudentContext(_contextOptions);

        public void Dispose() => _connection.Dispose();

        [TestMethod]
        public async Task Test_Repository_GetAll()
        {
            using var context = CreateContext();
            var repo = new StudentRepository(CreateContext());

            var students = await repo.GetStudentsAsync();

            Assert.IsNotNull(students);
            Assert.AreEqual(2, students.Count());
        }

        [TestMethod]
        public async Task Test_Repository_GetById()
        {
            using var context = CreateContext();
            var repo = new StudentRepository(CreateContext());

            var student = await repo.GetStudentByIdAsync(2);

            Assert.IsNotNull(student);
            Assert.AreEqual(2, student.ID);
        }

        [TestMethod]
        public async Task Test_Repository_AddStudent()
        {
            using var context = CreateContext();
            var repo = new StudentRepository(CreateContext());

            var id = await repo.CreateStudentAsync(new Student()
            {
                Name = "test",
                Address1 = "123 Fake Street",
                City = "New York",
                State = "NY",
                PhoneNumber = "123-456-7890",
                Age = 33
            });

            Assert.AreEqual(3, id);
        }

        [TestMethod]
        public async Task Test_Repository_RemoveStudent()
        {
            using var context = CreateContext();
            var repo = new StudentRepository(CreateContext());

            await repo.RemoveStudentAsync(2);

            var students = await repo.GetStudentsAsync();
            Assert.IsNotNull(students);
            Assert.AreEqual(1, students.Count);
        }
    }
}