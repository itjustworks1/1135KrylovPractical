using _1135KrylovPracticalAPI.DB;

namespace _1135KrylovPracticalAPI.DTO;

public class CreateEmployeeDTO
{
    public EmployeeDTO employee { get; set; }
    public CredentialDTO credential { get; set; } 
}