using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Intrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Intrastructure.Repository;

public class UserRepository: IUserRepository
{
    private readonly MovieShopDbContext _dbContext;

    public UserRepository(MovieShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User> AddUser(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }
}