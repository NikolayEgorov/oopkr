namespace Interfaces;

using Models;

public interface IBase
{
    public Base GetLast();
    public Base GetById(int id);
    public Base SaveOne(Base model);
    public bool RemoveById(int id);
}