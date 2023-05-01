namespace Repositories;

using Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class BollerRepository : IBollers
{
    protected readonly DatabaseContext dbContext;
    
    public BollerRepository(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Base GetLast() => this.dbContext.Boller.OrderByDescending(i => i.id).First();
    public Base GetById(int id) => this.dbContext.Boller.Where(i => i.id == id).First();
    public List<Boller> All => this.dbContext.Boller.ToList();

    public Base SaveOne(Base model)
    {
        Boller boller = (Boller) model;

        if(boller.id > 0) {
            Boller dbBoller = (Boller) this.GetById(boller.id);
            
            dbBoller.consumptionPower = boller.consumptionPower;
            dbBoller.generatePower = boller.generatePower;
            boller = dbBoller;
        } else this.dbContext.Boller.Add(boller);

        this.dbContext.SaveChanges();
        return boller.id > 0 ? boller : this.GetLast();
    }

    public bool RemoveById(int id)
    {
        this.dbContext.Boller.Remove(new Boller { id = id });
        return this.dbContext.SaveChanges() > 0;
    }
}