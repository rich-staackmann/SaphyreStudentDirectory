using SaphyreStudentDirectory.DAL.Repositories;
using SaphyreStudentDirectory.Domain.Models;

namespace SaphyreStudentDirectory.Server
{
    public static class SeedData
    {
        public static void Initialize(StudentContext db)
        {
            if (db.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
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
                },
                new Student()
                {
                    ID = 3,
                    Name = "Alex Pampelmousse",
                    Address1 = "123 Fake Street",
                    City = "New York",
                    State = "NY",
                    PhoneNumber = "123-456-7890",
                    Age = 33
                },
                new Student()
                {
                    ID = 4,
                    Name = "Shirley Temple",
                    Address1 = "123 Fake Street",
                    City = "New York",
                    State = "NY",
                    PhoneNumber = "123-456-7890",
                    Age = 33
                },
                new Student()
                {
                    ID = 5,
                    Name = "Johny Ringo",
                    Address1 = "123 Fake Street",
                    City = "New York",
                    State = "NY",
                    PhoneNumber = "123-456-7890",
                    Age = 33
                }
            };

            db.Students.AddRange(students);
            db.SaveChanges();
        }
    }
}
