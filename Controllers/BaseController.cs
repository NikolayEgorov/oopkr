namespace Controllers;

using Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

public class BaseController: Controller
{
    protected readonly ILog? _log = null;

    public BaseController() {}

    public BaseController(ILog iLog)
    {
        this._log = iLog;
    }

    protected void info(string message)
    {
        this._log.Lg(message, Log.Type.info);
    }

    protected void log(string message)
    {
        this._log.Lg(message, Log.Type.log);
    }

    protected void debug(string message)
    {
        this._log.Lg(message, Log.Type.debug);
    }

    protected void warning(string message)
    {
        this._log.Lg(message, Log.Type.warning);
    }

    protected void error(string message)
    {
        this._log.Lg(message, Log.Type.error);
    }
}