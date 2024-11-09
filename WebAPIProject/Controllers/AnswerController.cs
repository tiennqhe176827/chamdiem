using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        [HttpGet("{idMaDe}")]
        public async Task<ActionResult<Answer>> getAnswerById(int idMaDe)
        {
            List<Answer> answerList = new List<Answer>();
            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    answerList = context.Answers.Where(x => x.Idmade == idMaDe)
                                                .Select(x => new Answer
                                                {
                                                    Idcauhoi = x.Idcauhoi,
                                                    Causo = x.Causo,
                                                    Dapan = x.Dapan
                                                })
                                                .ToList();


                    if (answerList.Count == 0)
                    {
                        return Ok(new { message = "Chưa có đáp án" });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(new { message = "Đã xảy ra lỗi khi truy xuất đáp án", error = ex.Message });
            }


            return Ok(answerList);
        }

        [HttpPut]
        public async Task<ActionResult> updateAnswerByIdAnswer(AnswerDTO answerDTO)
        {
            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    Answer answer = context.Answers.FirstOrDefault(x => x.Idcauhoi == answerDTO.Idcauhoi);
                    if (answer == null)
                    {
                        return NotFound("Câu trả lời không tồn tại.");
                    }

                    answer.Dapan = answerDTO.Dapan;
                    context.Answers.Update(answer);
                    context.SaveChanges();
                    return Ok("Cập nhật thành công.");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex);
            }
        }


        [HttpPost]
        public async Task<ActionResult> addNewAnswer(AnswerDTO answerDTO)
        {
            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    int CauSoMax = context.Answers
                                          .Where(x => x.Idmade == answerDTO.Idmade)
                                           .Max(x => (int?)x.Causo) ?? 0;

                    Console.WriteLine("cau hoi so "+CauSoMax);
                    Answer answer = new Answer()
                    {

                        Causo = CauSoMax+1,
                        Idmade = answerDTO.Idmade,
                        Dapan = answerDTO.Dapan
                    };
                    context.Answers.Add(answer);
                    context.SaveChanges();
                    return Ok();

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
