namespace ViewModels.Plants;

using Models;

public class UpdateViewModels
{
    public Plant plant;
    public List<Boller> bollers;

    public UpdateViewModels(Plant plant, List<Boller> bollers)
    {
        this.plant = plant;
        this.bollers = bollers;
    }
}