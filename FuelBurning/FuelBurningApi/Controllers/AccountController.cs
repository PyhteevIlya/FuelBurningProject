using Fuel_burning.Models;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ApplicationContext _context;
        public AccountController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel? user = await _context.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new UserModel { Login = model.Login, Password = model.Password };


                    _context.Users.Add(user);

                    await _context.SaveChangesAsync();
                    //-------------------------------



                    return Authenticate(user); // аутентификация


                }
                else
                    return BadRequest("Некорректные логин и(или) пароль");
            }
            return BadRequest(model);
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel? user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    return Authenticate(user); // аутентификация

                }
                return BadRequest("Некорректные логин и(или) пароль");
            }
            return BadRequest(model);
        }


        private JsonResult Authenticate(UserModel user)
        {
            // создаем один claim
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Login)
            };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2000)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JsonResult(new { status = 0, token });
        }


    }
}
