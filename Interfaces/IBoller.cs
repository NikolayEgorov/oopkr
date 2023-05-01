namespace Interfaces;

using Models;

public interface IBollers : IBase
{
    public List<Boller> All { get; }
}