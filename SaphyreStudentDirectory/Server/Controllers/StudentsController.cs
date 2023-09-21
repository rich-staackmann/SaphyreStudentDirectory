using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaphyreStudentDirectory.Domain.Models;
using SaphyreStudentDirectory.Domain.Services;
using SaphyreStudentDirectory.Client.ViewModels;

namespace SaphyreStudentDirectory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public StudentsController(IStudentService studentService, IMapper mapper, ILogger<StudentsController> logger)
        {
            _studentService = studentService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentVM>>> GetStudents()
        {
            try
            {
                var students = await _studentService.GetStudentsAsync();
                if (students == null)
                {
                    return NotFound();
                }

                return _mapper.Map<List<StudentVM>>(students);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentVM>> GetStudent(int id)
        {
            try
            {
                var student = await _studentService.GetStudentByIdAsync(id);

                if (student == null)
                {
                    return NotFound();
                }

                return _mapper.Map<StudentVM>(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentVM studentVM)
        {
            try
            {
                if (id != studentVM.ID)
                {
                    return BadRequest();
                }

                var student = _mapper.Map<Student>(studentVM);
                await _studentService.UpateStudentAsync(id, student);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentVM>> PostStudent(StudentVM studentVM)
        {
            try
            {
                var student = _mapper.Map<Student>(studentVM);
                var id = await _studentService.CreateStudentAsync(student);

                return CreatedAtAction("GetStudent", new { id = student.ID }, student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _studentService.GetStudentByIdAsync(id);
                if (student == null)
                {
                    return NotFound();
                }

                await _studentService.RemoveStudentAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
