using FSAproject.Models;
using FSAproject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly FsaContext _context;

    public AuthController(IAuthService authService, FsaContext context)
    {
        _authService = authService;
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        // Recherchez l'utilisateur dans la base de données
        var user = _context.Utilisateurs
            .FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

        if (user == null)
        {
            return Unauthorized(); // Utilisateur non authentifié
        }

        // Générer un token JWT
        var token = _authService.GenerateToken(user);

        return Ok(new { Token = token });
    }
}