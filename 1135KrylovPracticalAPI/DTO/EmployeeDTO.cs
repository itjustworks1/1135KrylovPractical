using _1135KrylovPracticalAPI.DB;

namespace _1135KrylovPracticalAPI.DTO;

public class EmployeeDTO
{
    public int Id { get; set; }
    
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public DateTime HireDate { get; set; }

    public bool IsActive { get; set; }
}