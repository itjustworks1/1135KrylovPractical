using Microsoft.AspNetCore.Mvc;

namespace _1135KrylovPracticalAPI.Controllers;

[Route("api/auth/[controller]")]
public class AuthController : Controller
{
    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        
        return View();
    }
    [HttpPost("profile")]
    public IActionResult Profile()
    {
        
        return View();
    }
}