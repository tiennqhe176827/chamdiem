using BusinessObject.DTO;
using BusinessObject.Models;
using BusinessObject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebClient.Controllers
{
    public class AnswerController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        private readonly HttpClient client;
        private readonly string AnswerApiUrl;

        public AnswerController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AnswerApiUrl = "https://localhost:7089/api/Answer";
        }

        public async Task<ActionResult> loadAnswer(int idMaDe)
        {
            List<Answer> answers = null;
            try
            {
                HttpResponseMessage httpResponseMessage = await client.GetAsync(AnswerApiUrl + "/" + idMaDe);
                HttpResponseMessage httpResponseMessage1 = await client.GetAsync("https://localhost:7089/api/TirtleCode/getTitleCodeById/" + idMaDe);
                if (httpResponseMessage1.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Titlecode titlecode=httpResponseMessage1.Content.ReadFromJsonAsync<Titlecode>().Result;
                    int ?totalMark = titlecode.Totalmark;
                    ViewBag.totalMark=totalMark;
                }
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    answers = await httpResponseMessage.Content.ReadFromJsonAsync<List<Answer>>();

                    if (answers != null)
                    {

                        return View("Index", answers);
                    }
                    else
                    {
                        ViewBag.Empty = "Chưa có đáp án";
                        return View("Index");
                    }
                }
                else
                {
                    ViewBag.Error = "Lỗi API";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Danh sách đáp án rỗng ";
                return View("Index");
            }
        }


        public async Task<ActionResult> loadAnswerToUpdate(int idMaDe)
        {
            List<Answer> answers = null;
            AnswerVM answerVM = new AnswerVM();
            HttpContext.Session.SetInt32("idMaDe", idMaDe);
            try
            {
                HttpResponseMessage httpResponseMessage = await client.GetAsync(AnswerApiUrl + "/" + idMaDe);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    answers = await httpResponseMessage.Content.ReadFromJsonAsync<List<Answer>>();

                    if (answers != null)
                    {
                        answerVM.answersList = answers;
                        return View("AddOrUpdateAnswerForm", answerVM);
                    }
                    else
                    {
                        ViewBag.Empty = "Chưa có đáp án";
                        return View("AddOrUpdateAnswerForm", answerVM);
                    }
                }
                else
                {
                    ViewBag.Error = "Lỗi API";
                    return View("AddOrUpdateAnswerForm");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Danh sách đáp án rỗng ";
                return View("AddOrUpdateAnswerForm", answerVM);
            }
        }



        public async Task<IActionResult> Update(AnswerVM answerVM)
        {
            Console.WriteLine($"Idmade: {answerVM.Answer.Idmade}");
            Console.WriteLine($"Causo: {answerVM.Answer.Causo}");
            Console.WriteLine($"Dapan: {answerVM.Answer.Dapan}");

            try
            {
                HttpResponseMessage httpResponseMessage = await client.PutAsJsonAsync(AnswerApiUrl, answerVM.Answer);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("loadAnswerToUpdate", new { idMaDe = HttpContext.Session.GetInt32("idMaDe") });
                }
                else
                {
                    Console.WriteLine($"Lỗi khi cập nhật: {httpResponseMessage.StatusCode}");
                    ViewBag.ErrorMessage = "Cập nhật thất bại. Vui lòng thử lại sau.";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ngoại lệ: {e.Message}");
                ViewBag.ErrorMessage = "Đã xảy ra lỗi trong quá trình cập nhật.";
            }

            return RedirectToAction("loadAnswerToUpdate", new { idMaDe = HttpContext.Session.GetInt32("idMaDe") });
        }

        public async Task<IActionResult> Add(AnswerVM answerVM)
        {
            try
            {

                Answer answer = answerVM.Answer;
                answer.Idmade = HttpContext.Session.GetInt32("idMaDe");

                HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(AnswerApiUrl, answer);
                return RedirectToAction("loadAnswerToUpdate", new { idMaDe = HttpContext.Session.GetInt32("idMaDe") });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction("loadAnswerToUpdate", new { idMaDe = HttpContext.Session.GetInt32("idMaDe") });
            }

        }

    }
}
