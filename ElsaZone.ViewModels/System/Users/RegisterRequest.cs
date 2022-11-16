namespace ElsaZone.ViewModels.System.Users;

public class RegisterRequest
{
    public string AccountId { set; get; }
    public string Password { set; get; }
    public string ConfirmPassword { set; get; }
    public string Email { get; set; }
    public string DisplayName { set; get; }
}