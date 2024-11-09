using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSController : ControllerBase
    {
        [HttpPost("{teacherId}")]
        public async Task<ActionResult> GetTsByTeacherID(int teacherId)
        {
            List<TSDTO> teacherSubjectList = null;
            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    teacherSubjectList = context.TeacherSubjects.Include(x => x.Subject)
                        .Where(x => x.Teacherid == teacherId).Select(x => new TSDTO
                        {
                            TSId = x.Id,
                            Subjectname = x.Subject.Subjectname
                        }).ToList();
                    if (teacherSubjectList != null)
                    {
                        return Ok(teacherSubjectList);
                    }
                    else
                    {
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex);
            }
        }




        [HttpGet("teachers")]
        public async Task<ActionResult<List<Teacher>>> LoadAllTeachers()
        {
            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    var teachers = await context.Teachers.ToListAsync();
                    if (teachers.Any())
                    {
                        return Ok(teachers);
                    }
                    else
                    {
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex);
            }
        }

        [HttpGet("subjects")]
        public async Task<ActionResult<List<Subjecttable>>> LoadAllSubjects()
        {
            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    var subjects = await context.Subjecttables.ToListAsync();
                    if (subjects.Any())
                    {
                        return Ok(subjects);
                    }
                    else
                    {
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex);
            }
        }






        ///////////////
        ///


        [HttpPost("add/{teacherId}/{subjectId}")]
        public async Task<ActionResult> AddTeacherSubject(int teacherId, int subjectId)
        {

            TeacherSubject teacherSubject = new TeacherSubject()
            {
                Subjectid = subjectId,
                Teacherid = teacherId,
            };

            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    context.TeacherSubjects.Add(teacherSubject);
                    context.SaveChangesAsync();
                }

                return CreatedAtAction(nameof(GetTsByTeacherID), new { teacherId = teacherSubject.Teacherid }, teacherSubject);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving data.");
            }
        }



    }
}
