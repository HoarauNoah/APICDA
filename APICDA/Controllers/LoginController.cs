using APICDA.Data;
using APICDA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace APICDA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly string _apiKey;

        public LoginController(ShopDbContext context, IConfiguration configuration)
        {
            _context = context;
            _apiKey = configuration.GetValue<string>("APICDA:PrivateKey");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Vérifiez les informations d'identification ici et renvoyez un code d'erreur si elles ne sont pas valides.
            if (LoginExists(username, password) == false)
            {
                return Unauthorized();
            }

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_apiKey));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: username,
                audience: username,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        private bool LoginExists (string login, string password)
        {
            User leUser = _context.Users.FirstOrDefault(u => u.login == login);
            if (leUser != null)
            {
                SHA256 sha256 = SHA256.Create();
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashString = Encoding.UTF8.GetString(hashBytes);
                password = hashString;
                if (leUser.password == password)
                {
                    return true;
                }
            };
            return false;
        }
    }
}
