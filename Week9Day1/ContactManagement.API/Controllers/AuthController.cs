using Microsoft.AspNetCore.Mvc;
using ContactManagement.API.DTOs;
using ContactManagement.API.Services;

namespace ContactManagement.API.Controllers;

[ApiController]
[Route("api/[conteroller]")]
public class AuthController : ControllerBase
{
    public readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDto dto)
    {
        return Ok(_service.Register(dto));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        var token = _service.Login(dto);

        if (token == null)
        {
            return Unauthorized("Invalid credentials");
        }

        return Ok(new { Token = token });
    }
}