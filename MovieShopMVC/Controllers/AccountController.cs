using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MovieShopMVC.Controllers;

public class AccountController: Controller
{
    private readonly IAccountService _accountService;
    public IActionResult Login()
    {
        return View();
    }

    public async Task<IActionResult> Login(UserLoginModel model)
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterModel model)
    {
        var userId = await _accountService.RegisterUser(model);
        if (userId > 0)
        {
            return RedirectToAction("Login");
        }
        
        return View();
    }
 
    /*public async Task<UserLoginSuccessModel> ValidateUser(UserLoginModel model)
    {
        var user = await _userRepository.GetUserByEmail(model.Email);
        if (user == null)
        {
            throw new Exception("Email does not exist, try to register first");

            var hasedPassword = GetHashedPassword(model.Password, user.Salt);
            
            if()
        }
    }*/
}