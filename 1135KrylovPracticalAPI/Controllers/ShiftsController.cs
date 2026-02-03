using Microsoft.AspNetCore.Mvc;

namespace _1135KrylovPracticalAPI.Controllers;

[Route("api/[controller]")]
public class ShiftsController : Controller
{
    [HttpGet("shifts")]
    public IActionResult Shifts()
    {
        
        return View();
    }
    
    [HttpGet("shifts/{id}")]
    public IActionResult ShiftOnId()
    {
        
        return View();
    }
    
    [HttpGet("shifts/employee/{id}")]
    public IActionResult ShiftEmployeeOnId()
    {
        
        return View();
    }
    
    [HttpPost("shifts")]
    public IActionResult AddShift()
    {
        
        return View();
    }
    
    [HttpPut("shifts/{id}")]
    public IActionResult UpdateShift()
    {
        
        return View();
    }
    
    [HttpDelete("shifts/{id}")]
    public IActionResult DeleteShift()
    {
        
        return View();
    }
    
}