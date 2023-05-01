namespace Controllers;

using Enums;
using Models;
using Interfaces;
using ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

[Route("users")]
// [Route("[contorller]/[action]")]
public class UsersController : Controller
{
    private readonly IUsers _users;

    public UsersController(IUsers users)
    {
        _users = users;
    }

    public IActionResult index()
    {
        string orderBy = HttpContext.Request.Query["orderBy"];
        if(orderBy == null) orderBy = "id";

        string order = HttpContext.Request.Query["order"];
        if(order == null) order = SortingEnum.ASC;

        IndexViewModels viewModels = new IndexViewModels((List<User>)_users.All);

        return View(viewModels);
    }

    [Route("/create")]
    public IActionResult create()
    {
        return View();
    }

    [HttpGet]
    [Route("/update/{id:int}")]
    public IActionResult update(int id)
    {
        User user = (User) this._users.GetById(id);
        return View(new UpdateViewModels(user));
    }

    [HttpPost]
    [Route("/update")]
    public RedirectResult update(User user)
    {
        user = (User) this._users.SaveOne(user);
        return Redirect("/users/update/" + user.id);
    }

    [HttpPost]
    [Route("/delete/{id:int}")]
    public ActionResult delete(int id)
    {
        _users.RemoveById(id);
        return Redirect("/users/index");
    }
}