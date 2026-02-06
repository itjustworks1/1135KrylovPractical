using _1135KrylovPracticalAPI.DB;
using _1135KrylovPracticalAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace _1135KrylovPracticalAPI.Controllers;


[Route("api/[controller]")]
public class EmployeesController : Controller
{
    public _1135krylovPracticalContext db { get; set; }
    public EmployeesController(_1135krylovPracticalContext db)
    {
        this.db = db;
    }
    [HttpGet("employees")]
    public ActionResult<List<EmployeeDTO>> Employees()
    {
        List<EmployeeDTO> list = new List<EmployeeDTO>();
        foreach (Employee employee in db.Employees)
        {
            list.Add(new EmployeeDTO()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position =  employee.Position,
                HireDate =  employee.HireDate,
                IsActive =  employee.IsActive,
                Role = db.Credentials.FirstOrDefault(x => x.EmployeeId == employee.Id).Role
            });
        }
        return Ok(list);
    }
    
    [HttpGet("employees/{id}")]
    public ActionResult<EmployeeDTO> EmployeeOnId(int id)
    {
        Employee employee = db.Employees.FirstOrDefault(x => x.Id == id);
        if (employee == null)
            return NotFound();
        return Ok(new EmployeeDTO()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Position =  employee.Position,
            HireDate =  employee.HireDate,
            IsActive =  employee.IsActive,
            Role = db.Credentials.FirstOrDefault(x => x.EmployeeId == employee.Id).Role
        });
    }
    
    [HttpPost("employees")]
    public ActionResult AddEmployee(EmployeeDTO employeeDTO)
    {
        if (db.Credentials.FirstOrDefault(x => x.Username == employeeDTO.Username) != null)
            return BadRequest();
        db.Add(new Employee()
        {
            FirstName =  employeeDTO.FirstName,
            LastName =  employeeDTO.LastName,
            Position =  employeeDTO.Position,
            HireDate =  employeeDTO.HireDate,
            IsActive =  employeeDTO.IsActive
        });
        Credential credential = new Credential()
        {
            Username = employeeDTO.Username,
            EmployeeId =  employeeDTO.Id,
            PasswordHash = employeeDTO.PasswordHash,
            RoleId = employeeDTO.Role.Id
        };
        db.Credentials.Add(credential);
        db.SaveChanges();
        return Created($"/api/employees/{employeeDTO}", credential);
    }
    
    [HttpPut("employees/{id}")]
    public ActionResult UpdateEmployee(int id, EmployeeDTO employeeDTO)
    {
        db.Employees.Update(new Employee()
        {
            Id =  id,
            FirstName = employeeDTO.FirstName,
            LastName = employeeDTO.LastName,
            Position =  employeeDTO.Position,
            HireDate =  employeeDTO.HireDate,
            IsActive =  employeeDTO.IsActive
        });
        db.SaveChanges();
        return Ok();
    }
    
    [HttpDelete("employees/{id}")]
    public ActionResult DeleteEmployee(int id)
    {
        try
        {
            db.Employees.Remove(db.Employees.First(x => x.Id == id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        db.SaveChanges();
        return NoContent();
    }

}