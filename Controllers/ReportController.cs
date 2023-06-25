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

    [Route("add")]
    public ActionResult add()
    {
        return StatusCode(200, JsonSerializer.Serialize(
            new SettingsResponseDto(Plant.SumsCalculate(this._dbContext))));
    }

    [HttpGet]
    [Route("plants/set-random-settings")]
    public ActionResult randomSettings()
    {
        Plant pContext = new Plant(this._dbContext);
        PlantBollerRepository pbRepository = new PlantBollerRepository(pContext.GetDbContext());


        foreach(Plant plant in pContext.GetDbContext.Plant.Where(pContext => pContext.id > 0).ToList()) {
            foreach (PlantBoller pb in plant.plantBollers) {
                pb.currentPower = (new Random()).Next(101);
                pbRepository.SaveOne(pb);
            }
        }

        return StatusCode(200, JsonSerializer.Serialize(new SettingsResponseDto(true)));
    }
}