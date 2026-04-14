using ContactManagement.API.DTOs;

namespace ContactManagement.API.Services;

public interface IAuthService
{
    string Register(RegisterDto dto);
    string Login(LoginDto dto);
}