namespace src.Services.Repositories.Auth.RegisterRepository;

public interface IRegisterRepository
{
    Task<bool> UserExists(string Email);
    Task<bool> UserExists(Guid id);
    Task<bool> CreateNewUser();
}