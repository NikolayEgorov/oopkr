namespace Interfaces;

using Models;

public interface IPlants : IBase
{
    public List<Plant> All { get; }
    public bool SaveBollers(Plant plant);
}