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
    [HttpPost("login")]
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

    [HttpPost("profile")]
    public ActionResult<EmployeeDTO> Profile(int id)
    {
        Employee employee = db.Employees.FirstOrDefault(x => x.Id == id);
        return Ok(new EmployeeRoleDTO
            {
                employee = new EmployeeDTO
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Position =  employee.Position,
                    HireDate =  employee.HireDate,
                    IsActive =  employee.IsActive,
                },
                role = new RoleDTO
                {
                    Title = db.Credentials.FirstOrDefault(x => x.EmployeeId == employee.Id).Role.Title
                }
            });
    }
    
    
}