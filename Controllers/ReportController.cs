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
        Plant contextPlant = new Plant(this._dbContext);
        if(Int32.Parse(DateTime.Now.ToString("HH")) == 0) {
            contextPlant.SetRandomSettings();
        }

        return StatusCode(200, JsonSerializer.Serialize(
            new SettingsResponseDto(contextPlant.SumsCalculate(hour))));
    }
}