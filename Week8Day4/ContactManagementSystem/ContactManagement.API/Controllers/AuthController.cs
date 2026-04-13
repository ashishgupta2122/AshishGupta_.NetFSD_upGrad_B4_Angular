using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using ContactManagement.DAL.Data;
using ContactManagement.DAL.Models;

namespace ContactManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        //  REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Invalid data");

            // Optional: check duplicate user
            var exists = await _context.Users.AnyAsync(u => u.UserName == user.UserName);
            if (exists)
                return BadRequest("User already exists");

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        //  LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User login)
        {
            if (login == null)
                return BadRequest("Invalid data");

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == login.UserName && x.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid username or password");

            var token = GenerateToken(user);
            return Ok(new { token });
        }

        //  TOKEN GENERATION
        private string GenerateToken(User user)
        {
            var jwtKey = _config["Jwt:Key"] ?? throw new Exception("JWT Key missing");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}