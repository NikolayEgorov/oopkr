namespace Controllers;

using Dto;
using Models;
using Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

public class AccountController : Controller
{
    private readonly IUsers _iUsers;

    public AccountController(IUsers iUsers)
    {
        this._iUsers = iUsers;
    }

    public IActionResult Login()
    {
        ClaimsPrincipal user = HttpContext.User;
        Console.WriteLine(user.Identity.IsAuthenticated);

        if(user.Identity.IsAuthenticated) {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserDto request)
    {
        User user = this._iUsers.AuthenticateUser(request);
        if(user != null) {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, request.email)
                // new Claim("OtherProperties", "Example Role")
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties() {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults
                .AuthenticationScheme, new ClaimsPrincipal(identity), properties);

            return RedirectToAction("Index", "Home");
        }
        
        ViewData["authMessage"] = "Такого користувача не знайдено";
        return View();
    }

    [Authorize]
    public ActionResult<User> logout(UserDto request)
    {
        return RedirectToAction("Login", "Account");
    }
}