using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Infra;

namespace MovieShopMVC.Controllers;


[Authorize]
public class UserController : Controller
{
    private readonly ICurrentUser _currentUser;

    public UserController(ICurrentUser currentUser)
    {
        _currentUser = currentUser;
    }
    
    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> Buy()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Review()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IActionResult> Purchases()
    {
        var userId = _currentUser.UserId;
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> Favorites()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> EditProfile(UserEditModel model)
    {
        return View();
    }
}