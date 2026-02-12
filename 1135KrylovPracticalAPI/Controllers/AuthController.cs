using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using _1135KrylovPracticalAPI.DB;
using _1135KrylovPracticalAPI.DTO;
using _1135KrylovPracticalAPI.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
    public async Task<ActionResult> Login(string username, string password)
    {
        try
        {
            var credential = await db.Credentials.Include(x=> x.Role).FirstOrDefaultAsync(c=> c.Username == username);
            if (credential == null)
                return Unauthorized();
            
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, credential.PasswordHash);

            if (!isValidPassword)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, credential.Username),
                new Claim(ClaimTypes.Role, credential.Role.Title),
                new Claim("EmployeeId", credential.EmployeeId.ToString()),
            };

            var key = JwtSettings.GetSymmetricSecurityKey();
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expirensIn = 3600;

            var toker = new JwtSecurityToken(
                issuer: JwtSettings.ISSUER,
                audience: JwtSettings.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(expirensIn),
                signingCredentials: creds
            );
            return Ok(new LoginResponseDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(toker),
                ExpiresIn = expirensIn
            });
        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
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