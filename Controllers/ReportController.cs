namespace Controllers;

using Models;
using Interfaces;
using Dto.Plants;
using Repositories;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

[Route("report")]
public class ReportController: BaseController
{
    private readonly DatabaseContext _dbContext;

    public ReportController(ILog iLog, DatabaseContext databaseContext): base(iLog)
    {
        this._dbContext = databaseContext;
    }

    [Route("add/{hour:int}")]
    public ActionResult add(int hour)
    {
        return StatusCode(200, JsonSerializer.Serialize(
            new SettingsResponseDto(Plant.SumsCalculate(hour, this._dbContext))));
    }

    [HttpGet]
    [Route("plants/set-random-settings")]
    public ActionResult randomSettings()
    {
        PlantRepository pRepository = new PlantRepository(this._dbContext);
        PlantBollerRepository pbRepository = new PlantBollerRepository(this._dbContext);

        foreach(Plant plant in pRepository.All) {
            foreach (PlantBoller pb in plant.plantBollers) {
                pb.currentPower = (new Random()).Next(101);
                pbRepository.SaveOne(pb);
            }
        }

        return StatusCode(200, JsonSerializer.Serialize(new SettingsResponseDto(true)));
    }
}