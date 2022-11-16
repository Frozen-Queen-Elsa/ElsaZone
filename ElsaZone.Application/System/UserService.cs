using ElsaZone.Data.Entities;
using ElsaZone.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;

namespace ElsaZone.Application.System;

public class UserService:IUserService
{
    public UserService(UserManager<AppUser> userManager,SignIn)
    public Task<bool> Authenticate(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Register(RegisterRequest request)
    {
        throw new NotImplementedException();
    }
}