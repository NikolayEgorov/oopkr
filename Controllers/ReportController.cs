namespace Controllers;

using Models;
using Interfaces;
using Dto.Plants;
using System.Text.Json;
using System.Data.SqlClient;
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
}