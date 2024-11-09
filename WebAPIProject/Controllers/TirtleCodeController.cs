using BusinessObject.DTO;

using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TirtleCodeController : ControllerBase
    {

        [HttpPost("{teacherId}")]
        public async Task<ActionResult> getAllCodeByTeacherId(int teacherId)
        {
            List<TitleCodeDTO> TitleCodeDTO = new List<TitleCodeDTO>();
            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    //TitleCodeDTO = context.Titlecodes.Where(x => x.TeacherSubject.Teacherid == teacherId)
                    //    .Join(context.Classes, tc => tc.Classid, cl => cl.Classid, (tc, cl) => new { tc, cl })
                    //    .Join(context.TeacherSubjects, t1 => t1.tc.TeacherSubjectId, ts => ts.Id, (t1, ts) => new { t1, ts })
                    //    .Join(context.Subjecttables, t2 => t2.ts.Subjectid, st => st.Subjectid, (t2, st) => new { t2, st })
                    //    .Select(x => new TitleCodeDTO
                    //    {
                    //        Classname = x.t2.t1.cl.Classname,
                    //        Subjectname = x.st.Subjectname,
                    //        Titlecodeid = x.t2.t1.tc.Titlecodeid,
                    //        Titlecodenumber = x.t2.t1.tc.Titlecodenumber
                    //    })
                    //    .ToList();


                    TitleCodeDTO = (from tc in context.Titlecodes
                                    join cl in context.Classes
                                    on tc.Classid equals cl.Classid
                                    join ts in context.TeacherSubjects
                                    on tc.TeacherSubjectId equals ts.Id
                                    join st in context.Subjecttables
                                    on ts.Subjectid equals st.Subjectid
                                    where tc.TeacherSubject.Teacherid == teacherId
                                    select new TitleCodeDTO
                                    {
                                        Classname = cl.Classname,
                                        Subjectname = st.Subjectname,
                                        Titlecodeid = tc.Titlecodeid,
                                        Titlecodenumber = tc.Titlecodenumber
                                    }
                                   ).ToList();

                    return Ok(TitleCodeDTO);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex);
            }


        }

        [HttpPost("add")]
        public async Task<IActionResult> addNewTitleCode([FromBody] TitleCodeDTOAdd titleCodeDTOAdd)
        {
            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    Titlecode titlecode = new Titlecode()
                    {
                        Titlecodenumber = titleCodeDTOAdd.Titlecodenumber,
                        Classid = titleCodeDTOAdd.Classid,
                        TeacherSubjectId = titleCodeDTOAdd.TeacherSubjectId,
                        Totalmark = titleCodeDTOAdd.totalMark,
                    };

                    context.Titlecodes.Add(titlecode);

                    await context.SaveChangesAsync();
                }

                return Ok("Title code added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("{titlecodeid}")]
        public async Task<IActionResult> delete(int titlecodeid)
        {
            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    Titlecode titlecode = await context.Titlecodes.FindAsync(titlecodeid);
                    if (titlecode == null)
                    {
                        return NotFound($"Titlecode with ID {titlecodeid} not found.");
                    }

                    List<Answer> answers = context.Answers.Where(x => x.Idmade == titlecodeid).ToList();

                    if (answers.Any())
                    {
                        context.Answers.RemoveRange(answers);
                    }

                    context.Titlecodes.Remove(titlecode);
                    await context.SaveChangesAsync(); // Chỉ cần gọi SaveChangesAsync một lần
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest($"Error occurred while deleting: {ex.Message}");
            }
        }


        [HttpGet("getTitleCodeById/{idMaDe}")]
        public async Task<IActionResult> getTitleCodeById(int idMaDe)
        {
            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    Titlecode titlecode = context.Titlecodes.FirstOrDefault(x => x.Titlecodeid == idMaDe);
                    return Ok(titlecode);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest($"Error occurred while deleting: {ex.Message}");
            }


        }
    }
}
