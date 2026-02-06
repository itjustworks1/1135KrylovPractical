using _1135KrylovPracticalAPI.DB;
using _1135KrylovPracticalAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace _1135KrylovPracticalAPI.Controllers;

[Route("api/auth/[controller]")]
public class AuthController : Controller
{
    public _1135krylovPracticalContext db { get; set; }
    public AuthController(_1135krylovPracticalContext db)
    {
        this.db = db;
    }
    [HttpPost("auth/login")]
    public ActionResult Login(string username, string password)
    {
        try
        {

        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
        return View();
    }

    [HttpPost("auth/profile")]
    public ActionResult<EmployeeDTO> Profile(int id)
    {
        Employee employee = db.Employees.FirstOrDefault(x => x.Id == id);
        return Ok( new EmployeeDTO()
            {
                Id = employee.Id, FirstName = employee.FirstName, LastName = employee.LastName,
                Position = employee.Position,
                Role = db.Credentials.FirstOrDefault(x => x.EmployeeId == employee.Id).Role
            }
        );
    }
    
    
}