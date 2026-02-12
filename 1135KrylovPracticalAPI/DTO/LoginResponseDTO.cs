namespace _1135KrylovPracticalAPI.DTO;

public class LoginResponseDTO
{
    public string Token { get; set; } = null!;
    public int ExpiresIn { get; set; }
}