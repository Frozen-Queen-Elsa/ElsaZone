using ElsaZone.ViewModels.System.Users;

namespace ElsaZone.Application.System;

public interface IUserService
{
    Task<bool> Authenticate(LoginRequest request);
    Task<bool> Register(RegisterRequest request);
   
}