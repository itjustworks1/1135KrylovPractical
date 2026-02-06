using _1135KrylovPracticalAPI.DB;

namespace _1135KrylovPracticalAPI.DTO;

public class EmployeeDTO
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int Id { get; set; }

    public DateTime HireDate { get; set; }

    public bool IsActive { get; set; }
    public Role? Role { get; set; }
    
    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}