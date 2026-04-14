using ContactManagement.API.Data;
using ContactManagement.API.DTOs;
using ContactManagement.API.Helpers;
using ContactManagement.API.Models;

namespace ContactManagement.API.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public AuthService(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public string Register(RegisterDto dto)
    {
        var user = new UserInfo
        {
            EmailId = dto.EmailId,
            Password = dto.Password,
            Role = dto.Role
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return "User Registered";
    }

    public string Login(LoginDto dto)
    {
        var user = _context.Users
            .FirstOrDefault(x => x.EmailId == dto.EmailId && x.Password == dto.Password);

        if (user == null)
            return null;

        return JwtHelper.GenerateToken(user, _config);
    }
}