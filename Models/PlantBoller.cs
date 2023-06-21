namespace Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PlantBoller: Base
{
    public int plantId { get; set; }
    public int bollerId { get; set; }

    public int currentPower {get; set; } = 0;

    public Plant plant { get; set; } = new Plant();
    public Boller boller { get; set; } = new Boller();
}