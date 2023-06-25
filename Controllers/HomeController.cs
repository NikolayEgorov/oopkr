namespace Controllers;

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
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseContext _db;

    public HomeController(ILogger<HomeController> logger, DatabaseContext db)
    {
        _logger = logger;
        this._db = db;
    }

    public IActionResult Index()
    {
        ClaimsPrincipal user = HttpContext.User;

        if(! user.Identity.IsAuthenticated) {
            return Redirect("/account/login");
        }

        IndexViewModels viewModels = new IndexViewModels(this._db);
        return View(viewModels);
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
