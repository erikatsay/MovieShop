using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Intrastructure.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            var user = await _accountService.RegisterUser(model);
            return Ok(user);
        }
        
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            var userSuccess = await _accountService.ValidateUser(model);
            if (userSuccess!=null && userSuccess.Id > 0)
            {
                return Ok(userSuccess);
            }

            // How to handle this error?
            return null;
        }
        
        [HttpGet]
        [Route("check-email")]
        public async Task<IActionResult> CheckEmail(string email){
            var emailExist = await _accountService.CheckEmail(email);
            return Ok(emailExist);

        }
    }
}
