using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entities;

namespace Intrastructure.Services;

public class AccountService:IAccountService
{
    private readonly IUserRepository _userRepository;

    public AccountService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> RegisterUser(UserRegisterModel model)
    {
        var user = await _userRepository.GetUserByEmail(model.Email);
        if (user != null)
        {
            throw new Exception("Email already exists, try to login");
        }

        var salt = GetRadeomSalt();

        var hashedPassword = GetHashedPassword(model.Password, salt);

        var dbUser = new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Salt = salt,
            HashedPassword = hashedPassword,
            DateOfBirth = model.DateOfBirth
        };

        var createdUser = await _userRepository.AddUser(dbUser);
        return createdUser.Id;
    }

    public async Task<UserLoginSuccessModel> ValidateUser(UserLoginModel model)
    {
        throw new NotImplementedException();
    }
    
    /*public Task<UserLoginModel> ValidateUser(UserLoginModel model)
    {
        throw new NotImplementedException();
    }*/

    private string GetRadeomSalt()
    {
        var randonBytes = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randonBytes);
        }

        return Convert.ToBase64String(randonBytes);
    }

    private string GetHashedPassword(string password, string salt)
    {
        var hased = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, Convert.FromBase64String(salt), KeyDerivationPrf.HMACSHA512, 10000, 256/8));
        return hased;
    }
    
}