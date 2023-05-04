namespace Controllers;

using Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

public class AuthedController : Controller
{
    private readonly IUsers _iUser;

    public AuthedController(IUsers _iUser)
    {
        // if (HttpContex) {
            // ViewData["Identity"] = this._iUser.GetByLogin(User.Identity.Name);

            // System.Web.HttpContext.Current.User.Identity.GetUserName();
        // }
    }
}