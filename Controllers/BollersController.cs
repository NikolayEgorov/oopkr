namespace Controllers;

using Models;
using Interfaces;
using ViewModels.Bollers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

[Authorize]
[Route("bollers")]
public class BollersController : Controller
{
    private readonly IBollers _iBollers;

    public BollersController(IBollers iBollers)
    {
        this._iBollers = iBollers;
    }

    [Route("index")]
    public IActionResult index()
    {
        IndexViewModels viewModels = new IndexViewModels(_iBollers.All);
        return View(viewModels);
    }

    [Route("create")]
    public IActionResult create()
    {
        List<Boller> bollers = this._iBollers.All;
        return View("/Views/Bollers/update.cshtml", new UpdateViewModels(new Boller()));
    }

    [HttpGet]
    [Route("update/{id:int}")]
    public IActionResult update(int id)
    {
        Boller boller = (Boller) this._iBollers.GetById(id);
        return View(new UpdateViewModels(boller));
    }

    [HttpPost]
    [Route("update")]
    public ActionResult update(Boller boller)
    {
        boller = (Boller) this._iBollers.SaveOne(boller);
        return RedirectToAction("index", "bollers");
    }

    [HttpPost]
    [Route("delete/{id:int}")]
    public ActionResult delete(int id)
    {
        this._iBollers.RemoveById(id);
        return RedirectToAction("index", "bollers");
    }
}