namespace Controllers;

using Enums;
using Models;
using Interfaces;
using ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUsers _users;

    public UsersController(IUsers users)
    {
        _users = users;
    }

    [Route("index")]
    public IActionResult index()
    {
        IndexViewModels viewModels = new IndexViewModels((List<User>)_users.All);
        return View(viewModels);
    }

    [Route("create")]
    public IActionResult create()
    {   
        return View("/Views/Users/update.cshtml", new UpdateViewModels(new User()));
    }

    [HttpGet]
    [Route("update/{id:int}")]
    public IActionResult update(int id)
    {
        User user = (User) this._users.GetById(id);
        return View(new UpdateViewModels(user));
    }

    [HttpPost]
    [Route("update")]
    public ActionResult update(User user)
    {
        if(user.id == 0) this._users.PasswordHashing(user);
        user = (User) this._users.SaveOne(user);

        return RedirectToAction("index", "Users");
    }

    [HttpPost]
    [Route("delete/{id:int}")]
    public ActionResult delete(int id)
    {
        _users.RemoveById(id);
        return RedirectToAction("index", "Users");
    }
}