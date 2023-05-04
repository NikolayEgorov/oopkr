namespace Controllers;

using Models;
using Interfaces;
using ViewModels.Home;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

[Authorize]
public class HomeController : Controller
{
    private readonly IPlants _iPlants;
    private readonly IBollers _iBollers;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IPlants iPlants, IBollers iBollers)
    {
        this._iPlants = iPlants;
        this._iBollers = iBollers;

        _logger = logger;
    }

    public IActionResult Index()
    {
        ClaimsPrincipal user = HttpContext.User;

        if(! user.Identity.IsAuthenticated) {
            return Redirect("/account/login");
        }

        List<Plant> plants = this._iPlants.All;
        List<Boller> bollers = this._iBollers.All;

        IndexViewModels model = new IndexViewModels(plants, bollers);
        return View(model);
    }

    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
