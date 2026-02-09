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
    [HttpGet]
    public ActionResult<List<EmployeeDTO>> Employees()
    {
        List<EmployeeRoleDTO> list = new List<EmployeeRoleDTO>();
        foreach (Employee employee in db.Employees)
        {
            list.Add(new EmployeeRoleDTO
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
        return Ok(list);
    }
    
    [HttpGet("{id}")]
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
            IsActive =  employee.IsActive
        });
    }
    
    [HttpPost]
    public ActionResult AddEmployee(CreateEmployeeDTO createEmployeeDto)
    {
        if (db.Credentials.FirstOrDefault(x => x.Username == createEmployeeDto.credential.Username) != null)
            return BadRequest();
        Employee employee = new Employee
        {
            FirstName =  createEmployeeDto.employee.FirstName,
            LastName =  createEmployeeDto.employee.LastName,
            Position =  createEmployeeDto.employee.Position,
            HireDate =  createEmployeeDto.employee.HireDate,
            IsActive =  createEmployeeDto.employee.IsActive
        };
        db.Employees.Add(employee);
        db.SaveChanges();
        Credential credential = new Credential
        {
            Username = createEmployeeDto.credential.Username,
            EmployeeId = db.Employees.Last().Id,
            PasswordHash = createEmployeeDto.credential.PasswordHash,
            RoleId = createEmployeeDto.credential.RoleId
        };
        db.Credentials.Add(credential);
        db.SaveChanges();
        Credential credential1 = db.Credentials.Last();
        CredentialDTO credentialDto = new CredentialDTO
        {
            EmployeeId = credential1.EmployeeId,
            Username = credential1.Username,
            PasswordHash = credential1.PasswordHash,
            RoleId = credential1.RoleId
        };
            
        return Created( "",credentialDto);
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateEmployee(int id, EmployeeDTO employeeDTO)
    {
        Employee employee = db.Employees.FirstOrDefault(x => x.Id == id);
        employee.FirstName = employeeDTO.FirstName;
        employee.LastName = employeeDTO.LastName;
        employee.Position = employeeDTO.Position;
        employee.HireDate = employeeDTO.HireDate;
        employee.IsActive = employeeDTO.IsActive;
        db.SaveChanges();
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteEmployee(int id)
    {
        try
        {
            db.Employees.Remove(db.Employees.FirstOrDefault(x => x.Id == id));
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