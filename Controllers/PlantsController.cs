namespace Controllers;

using Models;
using Interfaces;
using Dto.Plants;
using System.Text.Json;
using ViewModels.Plants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

[Authorize]
[Route("plants")]
public class PlantsController : BaseController
{
    private readonly IPlants _iPlants;
    private readonly IBollers _iBollers;
    private readonly IPlantsBollers _iPlantsBollers;

    public PlantsController(IPlants iPlants, IBollers iBollers, IPlantsBollers iPlantsBollers)
    {
        this._iPlants = iPlants;
        this._iBollers = iBollers;
        this._iPlantsBollers = iPlantsBollers;
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

    [HttpGet]
    [Route("settings/{id:int}")]
    public ActionResult settings(int id)
    {
        Plant plant = (Plant) this._iPlants.GetById(id);
        return View(new SettingsViewModels(plant));
    }

    [HttpPost]
    [Route("settings")]
    public ActionResult settings(SettingsDto request)
    {
        bool status = true;

        foreach(PlantBoller pb in request.plantBollers) {
            PlantBoller plantBoller = (PlantBoller) this._iPlantsBollers.SaveOne(pb);

            status = plantBoller != null;
            if(! status) break;
        }

        return StatusCode(200, JsonSerializer.Serialize(new SettingsResponseDto(status)));
    }

    [HttpPost]
    [Route("delete/{id:int}")]
    public ActionResult delete(int id)
    {
        this._iPlants.RemoveById(id);
        return RedirectToAction("index", "plants");
    }

    [HttpGet]
    [Route("random-settings")]
    public ActionResult randomSettings()
    {
        foreach(Plant plant in this._iPlants.All) {
            foreach (PlantBoller pb in plant.plantBollers) {
                pb.currentPower = (new Random()).Next(101);
                this._iPlantsBollers.SaveOne(pb);
            }
        }

        return StatusCode(200, JsonSerializer.Serialize(new SettingsResponseDto(true)));
    }
}