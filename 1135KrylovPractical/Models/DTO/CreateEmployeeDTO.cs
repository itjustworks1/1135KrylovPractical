using _1135KrylovPractical.DB;

namespace _1135KrylovPractical.DTO;

public class CreateEmployeeDTO
{
    public EmployeeDTO employee { get; set; }
    public CredentialDTO credential { get; set; } 
}