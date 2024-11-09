using Microsoft.AspNetCore.Mvc;

namespace ManagerTeacher.Controllers
{
    public class LoginAdminController : Controller
    {
        public IActionResult Index()
        {
            return View("LoginAdminForm");
        }

        [HttpPost]
        public IActionResult CheckLogin(string admin, string password)
        {
            if (admin == "admin" && password == "admin")
            {
                return RedirectToAction("Success");
            }
            ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return View("LoginAdminForm");
        }

        public IActionResult Success()
        {
            return View("SuccessPage");
        }
    }
}
