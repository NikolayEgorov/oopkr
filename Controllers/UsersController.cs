namespace Controllers;

using Enums;
using Models;
using Interfaces;
using ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

public class UsersController : Controller
{
    private readonly IUsers _users;

    public UsersController(IUsers users)
    {
        _users = users;
    }

    [Route("/users/index")]
    public IActionResult index()
    {
        string orderBy = HttpContext.Request.Query["orderBy"];
        if(orderBy == null) orderBy = "id";

        string order = HttpContext.Request.Query["order"];
        if(order == null) order = SortingEnum.ASC;

        IndexViewModels viewModels = new IndexViewModels((List<User>)_users.All);

        return View(viewModels);
    }

    [Route("/users/create")]
    public IActionResult create()
    {
        return View();
    }

    [HttpGet]
    [Route("/users/update/{id:int}")]
    public IActionResult update(int id)
    {
        User user = (User) this._users.GetById(id);
        return View(new UpdateViewModels(user));
    }

    [HttpPost]
    [Route("/users/update")]
    public RedirectResult update(User user)
    {
        user = (User) this._users.SaveOne(user);
        return Redirect("/users/update/" + user.id);
    }

    [HttpPost]
    [Route("/users/delete/{id:int}")]
    public ActionResult delete(int id)
    {
        _users.RemoveById(id);
        return Redirect("/users/index");
    }
}