using Drafter.Data.Entities;
using Drafter.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<DrafterUser> _signInManager;
        private readonly UserManager<DrafterUser> _userManager;
        private readonly IConfiguration _config;

        public AccountController(ILogger<AccountController> logger, SignInManager<DrafterUser> signInManager, UserManager<DrafterUser> userManager, IConfiguration config)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated) 
            {
                return RedirectToAction("MyTeams", "App"); // Will look for MyTeams action in App controller and go there
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username,
                    model.Password,
                    model.RememberMe,
                    false); // THIS IS A LOCKOUT VALUE IF PASSWORD WRONG
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("MyTeams", "App");
                    }
                }
            }
            ModelState.AddModelError("", "Failed to login");

            return View();
        }

        public IActionResult Register()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("MyTeams", "App"); // Will look for MyTeams action in App controller and go there
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                DrafterUser newUser = new DrafterUser()
                {
                    Email = model.Email,
                    UserName = model.Username
                };
                
                var result = await _userManager.CreateAsync(newUser, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Players", "App");
                }
            }
            ModelState.AddModelError("", "Failed to register");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "App");
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        //Create token
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            _config["Token:Issuer"],
                            _config["Token:Audience"],
                            claims,
                            signingCredentials: creds, expires: DateTime.UtcNow.AddMinutes(int.Parse(_config["Token:Timeout"]))); 

                        return Created("", new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        }) ;
                    }
                }
            }

            return BadRequest();
        }
    }
}
