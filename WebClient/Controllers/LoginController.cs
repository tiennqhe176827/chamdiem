using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WebClient.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient client;
        private readonly string teacherApiUrl;

        public LoginController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            teacherApiUrl = "https://localhost:7089/api/Teacher";
        }

        public IActionResult Index()
        {
            return View("LoginForm");
        }

        public static string GetClaimFromJwt(string token, string claimType)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var claim = jwtToken.Claims.FirstOrDefault(c => c.Type == claimType);
            return claim?.Value;
        }

        public async Task<IActionResult> CheckEmailAndPassword(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                ViewBag.Error = "Thông tin đăng nhập không hợp lệ.";
                return View("LoginForm");
            }

            try
            {
                HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(teacherApiUrl, loginDTO);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var token = await httpResponseMessage.Content.ReadAsStringAsync();
                    token = token.Trim('\"');

                    HttpContext.Session.SetString("isLogin", "true");
                    HttpContext.Session.SetString("teacherID", GetClaimFromJwt(token, "teacher"));
                    return RedirectToAction("LoadTitleCode", "TitleCode");
                }
                else
                {
                    ViewBag.Error = "Đăng nhập không thành công. Vui lòng kiểm tra lại thông tin.";
                    return View("LoginForm");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Đã xảy ra lỗi: {ex.Message}";
                return View("LoginForm");
            }
        }
    }
}
