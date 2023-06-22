namespace Controllers;

using Interfaces;
using Microsoft.AspNetCore.Mvc;

public class BaseController: Controller
{
    protected readonly ILog _log;
}