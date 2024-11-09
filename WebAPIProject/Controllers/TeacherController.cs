using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.DTO; // Đảm bảo bạn có đúng namespace cho LoginDTO
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TeacherController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private JwtSecurityToken GetToken(Teacher teacher)
        {
            var claims = new[]
      {
      new Claim(JwtRegisteredClaimNames.Sub, teacher.Teachername),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      new Claim("teacher",teacher.Teacherid.ToString())
  };
            var expire = DateTime.Now.AddDays(
_configuration.GetValue<int>("Jwt:ExpiryInDays"));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               issuer: _configuration["Jwt:Issuer"],
                 audience: _configuration["Jwt:Audience"],
               claims: claims,
                expires: expire,
                signingCredentials: creds
                );
            return token;
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            using (MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider())
            {
                byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));
                for (int i = 0; i < bytes.Length; i++)
                {
                    hash.Append(bytes[i].ToString("x2"));
                }
            }
            return hash.ToString();
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            Teacher teacher = new Teacher();
            try
            {
                using (PrjprnContext context = new PrjprnContext())
                {
                    teacher = context.Teachers.FirstOrDefault(x => x.Email.Equals(loginDTO.Email) && x.Password.Equals(MD5Hash(loginDTO.Password)));

                    if (teacher == null)
                    {
                        return Unauthorized(new { message = "Invalid email or password." });
                    }
                    else
                    {
                        JwtSecurityTokenHandler j = new JwtSecurityTokenHandler();
                        var token = j.WriteToken(GetToken(teacher));
                        return Ok(token);

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex);
            }

        }

        [HttpPost("addNewTeacher")]
        public IActionResult addNewTeacher(AddTeacherDTO addTeacherDTO)
        {
            try
            {
                using (PrjprnContext ctx = new PrjprnContext())
                {
                    Teacher teacher = new Teacher()
                    {
                        Email = addTeacherDTO.Email,
                        Password =MD5Hash( addTeacherDTO.Password),
                        Teachername = addTeacherDTO.Teachername
                    };
                    ctx.Teachers.Add(teacher);
                    ctx.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return BadRequest();
            }



        }



    }
}
