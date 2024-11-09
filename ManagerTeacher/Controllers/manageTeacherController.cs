using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ManagerTeacher.Controllers
{
    public class manageTeacherController : Controller
    {

        private readonly HttpClient client;


        public manageTeacherController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

        }

        public IActionResult addNewTeacher()
        {
            return View("addNewTeacherForm");
        }

        public async Task<IActionResult> AddTeacher(AddTeacherDTO addTeacherDTO)
        {
            try
            {
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync("https://localhost:7089/api/Teacher/addNewTeacher", addTeacherDTO);
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    return View("addNewTeacherForm");
                }
                else
                {
                    return View("addNewTeacherForm");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NoContent();

            }
        }


        public async Task<IActionResult> turnToSelectForm()
        {
            try
            {
                List<Teacher> teachers = new List<Teacher>();
                List<Subjecttable> subjecttables = new List<Subjecttable>();

                HttpResponseMessage teacherRespone = await client.GetAsync("https://localhost:7089/api/TS/teachers");
                HttpResponseMessage subjectRespone = await client.GetAsync("https://localhost:7089/api/TS/subjects");


                teachers = teacherRespone.Content.ReadFromJsonAsync<List<Teacher>>().Result;
                subjecttables = subjectRespone.Content.ReadFromJsonAsync<List<Subjecttable>>().Result;

                ViewBag.Teachers = teachers;
                ViewBag.Subjecttables = subjecttables;

                return View("selectForm");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NoContent();
            }
        }

        public async Task<IActionResult> selectTS(TeacherSubject teacherSubjectForm)
        {
            try
            {
                // Make sure the HttpClient is properly instantiated and available.
                HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(
                    $"https://localhost:7089/api/TS/add/{teacherSubjectForm.Teacherid}/{teacherSubjectForm.Subjectid}",
                    new { } // Use an empty anonymous object if you are not sending any additional data
                );

                // Check if the response is successful.
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    // You can handle any additional logic here if needed based on the response.
                    return RedirectToAction("turnToSelectForm");
                }
                else
                {
                    // Optionally log the status code or message for debugging.
                    Console.WriteLine($"Error: {httpResponseMessage.StatusCode}");
                    return StatusCode((int)httpResponseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent(); // Or return an appropriate status code/message
            }
        }

    }
}