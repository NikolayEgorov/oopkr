namespace Controllers;

using Models;
using Interfaces;
using ViewModels.Plants;
using Microsoft.AspNetCore.Mvc;

[Route("plants")]
public class PlantsController : Controller
{
    private readonly IPlants _iPlants;
    private readonly IBollers _iBollers;

    public PlantsController(IPlants iPlants, IBollers iBollers)
    {
        this._iPlants = iPlants;
        this._iBollers = iBollers;
    }

    [Route("index")]
    public IActionResult index()
    {
        IndexViewModels viewModels = new IndexViewModels(_iPlants.All);
        return View(viewModels);
    }

    [Route("create")]
    public IActionResult create()
    {
        List<Plant> plants = this._iPlants.All;
        return View("/Views/Plants/update.cshtml", new UpdateViewModels(new Plant(), this._iBollers.All));
    }

    [HttpGet]
    [Route("update/{id:int}")]
    public IActionResult update(int id)
    {
        Plant plant = (Plant) this._iPlants.GetById(id);
        List<Boller> bollers = this._iBollers.All;

        return View(new UpdateViewModels(plant, bollers));
    }

    [HttpPost]
    [Route("update")]
    public ActionResult update(Plant plant, List<Boller> bollers)
    {
        plant = (Plant) this._iPlants.SaveOne(plant);

        foreach (string bollerId in Helpers.ParseMultipleSelectValue(Request.Form, "bollerIds")) {
            bollers.Add((Boller) this._iBollers.GetById(Int32.Parse(bollerId)));
        }
        plant.bollers = bollers;

        this._iPlants.SaveBollers(plant);
        return RedirectToAction("index", "plants");
    }

    [HttpPost]
    [Route("delete/{id:int}")]
    public ActionResult delete(int id)
    {
        this._iPlants.RemoveById(id);
        return RedirectToAction("index", "plants");
    }
}