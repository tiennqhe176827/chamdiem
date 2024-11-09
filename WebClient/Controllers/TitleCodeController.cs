using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace WebClient.Controllers
{
    public class TitleCodeController : Controller
    {

        private readonly HttpClient client = null;
        private string TirtleCodeApiUrl = "";

        public TitleCodeController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            TirtleCodeApiUrl = "https://localhost:7089/api/TirtleCode";
        }

        public async Task<IActionResult> loadTitleCode()
        {
            if (HttpContext.Session.GetString("isLogin") != "true")
            {
                return View("~/Views/Login/LoginForm.cshtml");
            }

            Console.WriteLine("đã qua điều kiện 1 ");
            int teacherID = 0;
            if ((HttpContext.Session.GetString("teacherID") != null))
            {
                teacherID = int.Parse(HttpContext.Session.GetString("teacherID"));

            }
            Console.WriteLine("đã qua điều kiện 2 ");
            List<TitleCodeDTO> titleCodeDTOs = new List<TitleCodeDTO>();
            try
            {
                Console.WriteLine(TirtleCodeApiUrl + "/" + teacherID);
                HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(TirtleCodeApiUrl + "/" + teacherID, teacherID);
                Console.WriteLine(httpResponseMessage.StatusCode.ToString());

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    titleCodeDTOs = httpResponseMessage.Content.ReadFromJsonAsync<List<TitleCodeDTO>>().Result;
                    return View("Index", titleCodeDTOs);
                }
                else
                {
                    return View("~/Views/Login/LoginForm.cshtml");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return View("~/Views/Login/LoginForm.cshtml");

            }

        }

        public async Task<IActionResult> turnToAddTitleCodeForm()
        {
            string classAPI = "https://localhost:7089/api/Class";
            string TSAPI = "https://localhost:7089/api/TS";
            List<TSDTO> TeacherSubjectList = new List<TSDTO>();
            List<Class> ClassList = new List<Class>();

            int TeacherId = int.Parse(HttpContext.Session.GetString("teacherID"));

            try
            {
                HttpResponseMessage classHttpResponseMessage = await client.GetAsync(classAPI);
                HttpResponseMessage tsHttpResponseMessage = await client.PostAsync(TSAPI + "/" + TeacherId, null);
                Console.WriteLine(classHttpResponseMessage.Content.ToString());
                Console.WriteLine(tsHttpResponseMessage.Content.ToString());
                if (tsHttpResponseMessage.IsSuccessStatusCode)
                {
                    ClassList = classHttpResponseMessage.Content.ReadFromJsonAsync<List<Class>>().Result;
                    TeacherSubjectList = tsHttpResponseMessage.Content.ReadFromJsonAsync<List<TSDTO>>().Result;
                    ViewBag.ClassList = ClassList;
                    ViewBag.TeacherSubjectList = TeacherSubjectList;
                    return View("AddNewTitleCode");
                }
                else
                {
                    return View("AddNewTitleCode");
                }

            }
            catch (Exception ex)
            {
                return View("AddNewTitleCode");
            }



        }

        public async Task<IActionResult> addNewTitleCode(TitleCodeDTOAdd titlecode)
        {
            Console.WriteLine($"{titlecode.Titlecodenumber} {titlecode.Classid}");
            try
            {
                HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(TirtleCodeApiUrl + "/add", titlecode);

                return RedirectToAction("loadTitleCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent();
            }


        }



        public async Task<IActionResult> deleteTC(int idMaDe)
        {
          
            try
            {
                HttpResponseMessage httpResponseMessage = await client.DeleteAsync(TirtleCodeApiUrl + "/"+idMaDe);

                return RedirectToAction("loadTitleCode");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent();
            }


        }


        //public async Task<IActionResult> addNewTitleCode(TitleCodeDTOAdd titlecode)
        //{
        //    Console.WriteLine($"Title Code Number: {titlecode.Titlecodenumber}, Class ID: {titlecode.Classid}");

        //    try
        //    {
        //        HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(TirtleCodeApiUrl + "/add", titlecode);

        //        // Kiểm tra phản hồi từ API
        //        if (httpResponseMessage.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine("API call succeeded");
        //            return RedirectToAction("loadTitleCode");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"API call failed with status code: {httpResponseMessage.StatusCode}");
        //            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
        //            Console.WriteLine($"Response content: {responseContent}");
        //            return BadRequest("API call failed");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Exception occurred: {ex}");
        //        return NoContent();
        //    }
        //}


    }
}
