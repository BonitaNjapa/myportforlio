
using Microsoft.AspNetCore.Identity;
using portfolio.API.Entities.User;
using portfolio.API.Shared;

namespace src.Services.Repositories.Auth.RegisterRepository;

public class RegisterRepository : IRegisterRepository
{
    private readonly UserManager<User> _userManager;

    public RegisterRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task<bool> CreateNewUser()
    {
       await Task.Delay(5);
       return true;
    }

    public async Task<bool> UserExists(string Email)
    {
        return await _userManager.FindByEmailAsync(Email) is not null ? true : false;
    }

    public async Task<bool> UserExists(Guid id)
    {
      await Task.Delay(5);
    return true;
    }
}