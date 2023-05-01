namespace Repositories;

using Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class PlantRepository : IPlants
{
    protected readonly DatabaseContext dbContext;
    
    public PlantRepository(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Base GetLast() => this.dbContext.Plant
        .OrderByDescending(i => i.id).Include(p => p.bollers).First();

    public Base GetById(int id) => this.dbContext.Plant
        .Where(i => i.id == id).Include(p => p.bollers).First();

    public Base SaveOne(Base model)
    {
        Plant plant = (Plant) model;

        if(plant.id > 0) {
            Plant dbPlant = (Plant) this.GetById(plant.id);
            
            dbPlant.name = plant.name;
            plant = dbPlant;
        } else this.dbContext.Plant.Add(plant);

        this.dbContext.SaveChanges();
        return plant.id > 0 ? plant : this.GetLast();
    }

    public bool RemoveById(int id)
    {
        this.dbContext.Plant.Remove(new Plant { id = id });
        return this.dbContext.SaveChanges() > 0;
    }

    public List<Plant> All => this.dbContext.Plant.Include(p => p.bollers).ToList();

    public bool SaveBollers(Plant plant)
    {
        Plant dbPlant = (Plant) this.GetById(plant.id);
        dbPlant.bollers.AddRange(plant.bollers);
        
        return this.dbContext.SaveChanges() > 0;
    }
}