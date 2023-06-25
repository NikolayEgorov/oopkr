namespace Interfaces;

using Models;

public interface ILog: IBase
{
    public void Lg(string message, Log.Type type = Log.Type.log);
}