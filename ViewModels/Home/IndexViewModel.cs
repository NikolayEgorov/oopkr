namespace ViewModels.Home;

public class IndexViewModels
{
    public int monthGenerate;
    public int monthConsumption;

    public int allGenerate;
    public int allConsumption;

    public IndexViewModels()
    {
        this.monthGenerate = 500;
        this.monthConsumption = 350;

        this.allGenerate = 5000;
        this.allConsumption = 3500;
    }
}