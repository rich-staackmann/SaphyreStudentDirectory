using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SaphyreStudentDirectory.Domain.Models;
using SaphyreStudentDirectory.Domain.Services;
using SaphyreStudentDirectory.Server.Controllers;
using SaphyreStudentDirectory.Client.ViewModels;

namespace SaphyreStudentDirectory.Tests
{
    [TestClass]
    public class ApiTests
    {
        public readonly Student _student;
        public readonly StudentVM _studentVM;

        public ApiTests()
        {
            _student = new Student() { ID = 5, Address1 = "1123 fake st", City = "Chicago", State = "IL", Name = "Rich", PhoneNumber = "555-555-5555" };
            _studentVM = new StudentVM() { ID = 5, Address1 = "1123 fake st", City = "Chicago", State = "IL", Name = "Rich", PhoneNumber = "555-555-5555" };
        }

        [TestMethod]
        public async Task Test_Controller_GetStudentById_200()
        {
            var service = new Mock<IStudentService>();
            service.Setup(x => x.GetStudentByIdAsync(5)).Returns(Task.FromResult(_student));
            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.Map<StudentVM>(_student)).Returns(_studentVM);
            var logger = new Mock<ILogger<StudentsController>>();

            var controller = new StudentsController(service.Object, mapper.Object, logger.Object);

            var actionResult = await controller.GetStudent(5);

            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(5, actionResult.Value.ID);
        }

        [TestMethod]
        public async Task Test_Controller_GetStudentById_404()
        {
            var service = new Mock<IStudentService>();
            service.Setup(x => x.GetStudentByIdAsync(5)).Returns(Task.FromResult<Student>(null));
            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.Map<StudentVM>(_student)).Returns<StudentVM>(null);
            var logger = new Mock<ILogger<StudentsController>>();

            var controller = new StudentsController(service.Object, mapper.Object, logger.Object);

            var actionResult = await controller.GetStudent(5);
            var notFound = actionResult.Result as NotFoundResult;

            Assert.IsNotNull(notFound);
            Assert.AreEqual(404, notFound.StatusCode);
        }

        [TestMethod]
        public async Task Test_Controller_GetStudentById_500()
        {
            var service = new Mock<IStudentService>();
            service.Setup(x => x.GetStudentByIdAsync(5)).Throws(new Exception("my exception"));
            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.Map<StudentVM>(_student)).Returns<StudentVM>(null);
            var logger = new Mock<ILogger<StudentsController>>();

            var controller = new StudentsController(service.Object, mapper.Object, logger.Object);

            var actionResult = await controller.GetStudent(5);
            var error = actionResult.Result as ObjectResult;

            Assert.IsNotNull(error);
            Assert.AreEqual(500, error.StatusCode);
            Assert.AreEqual("my exception", error.Value);
        }
    }
}