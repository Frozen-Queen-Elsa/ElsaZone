namespace ElsaZone.ViewModels.System.Users;

public class LoginRequest
{
    public string Account { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}