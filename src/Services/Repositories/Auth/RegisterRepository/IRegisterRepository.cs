using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Services.Repositories.Auth.RegisterRepository;

public interface IRegisterRepository
{
    async Task<bool> UserExists(string userName,string Email);
    async Task<bool> CreateNewUser();
}