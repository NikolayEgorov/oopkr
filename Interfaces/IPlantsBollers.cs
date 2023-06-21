namespace Interfaces;

using Models;

public interface IPlantsBollers: IBase
{
    public List<PlantBoller> All { get; }
}