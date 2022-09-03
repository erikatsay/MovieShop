using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services;

public interface IUserService
{
    Task<User> GetUserByEmail(string email);
}