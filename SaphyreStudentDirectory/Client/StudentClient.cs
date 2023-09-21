using SaphyreStudentDirectory.Client.ViewModels;
using System.Net.Http.Json;

namespace SaphyreStudentDirectory.Client
{
    public class StudentClient
    {
        private readonly HttpClient _httpClient;

        public StudentClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StudentVM>> GetStudents()
        {
            return await _httpClient.GetFromJsonAsync<List<StudentVM>>("api/students");
        }

        public async Task<StudentVM> GetStudent(int id)
        {
            return await _httpClient.GetFromJsonAsync<StudentVM>($"api/students/{id}");
        }

        public async Task UpdateStudent(StudentVM student)
        {
            await _httpClient.PutAsJsonAsync<StudentVM>($"api/students/{student.ID}", student);
        }

        public async Task RemoveStudent(int id)
        {
            await _httpClient.DeleteAsync($"api/students/{id}");
        }

        public async Task<StudentVM> AddStudent(StudentVM student)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/students/", student);
            response.EnsureSuccessStatusCode();

            var studentWithId = await response.Content.ReadFromJsonAsync<StudentVM>();
            return studentWithId;
        }
    }
}
