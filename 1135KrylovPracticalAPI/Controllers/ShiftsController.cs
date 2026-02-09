using Microsoft.AspNetCore.Mvc;

namespace _1135KrylovPracticalAPI.Controllers;

[Route("api/[controller]")]
public class ShiftsController : Controller
{
    [HttpGet]
    public IActionResult Shifts()
    {
        
        return View();
    }
    
    [HttpGet("{id}")]
    public IActionResult ShiftOnId()
    {
        
        return View();
    }
    
    [HttpGet("employee/{id}")]
    public IActionResult ShiftEmployeeOnId()
    {
        
        return View();
    }
    
    [HttpPost]
    public IActionResult AddShift()
    {
        
        return View();
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateShift()
    {
        
        return View();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteShift()
    {
        
        return View();
    }
    
}