using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> getClass()
        {
            List<Class> classes = new List<Class>();
            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    classes = context.Classes.Select(x => new Class
                    {
                        Classid = x.Classid,
                        Classname = x.Classname
                    }).ToList();
                }
                if (classes != null)
                {
                    return Ok(classes);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex);
            }
        }
    }
}
