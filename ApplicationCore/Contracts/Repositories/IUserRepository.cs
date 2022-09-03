using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository;

public interface IUserRepository
{
    Task<User> GetUserByEmail(string email);
    Task<User> AddUser(User user);
}