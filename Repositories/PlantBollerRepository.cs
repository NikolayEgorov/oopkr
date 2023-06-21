namespace Repositories;

using Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class PlantBollerRepository: IPlantsBollers
{
    protected readonly DatabaseContext dbContext;
    
    public PlantBollerRepository(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Base GetLast() => this.dbContext.PlantBoller.OrderByDescending(i => i.id).First();
    public Base GetById(int id) => this.dbContext.PlantBoller.Where(i => i.id == id).First();
    public List<PlantBoller> All => this.dbContext.PlantBoller.ToList();

    public Base SaveOne(Base model)
    {
        PlantBoller plantBoller = (PlantBoller) model;

        if(plantBoller.id > 0) {
            Console.WriteLine(plantBoller.id);
            PlantBoller dbPlantBoller = (PlantBoller) this.GetById(plantBoller.id);
            
            dbPlantBoller.currentPower = plantBoller.currentPower;
            plantBoller = dbPlantBoller;
        } else this.dbContext.PlantBoller.Add(plantBoller);

        this.dbContext.SaveChanges();
        return plantBoller.id > 0 ? plantBoller : this.GetLast();
    }

    public bool RemoveById(int id)
    {
        this.dbContext.PlantBoller.Remove(new PlantBoller { id = id });
        return this.dbContext.SaveChanges() > 0;
    }
}