namespace ViewModels.Bollers;

using Models;

public class IndexViewModels {
    public IEnumerable<Boller> bollers;

    public IndexViewModels(IEnumerable<Boller> bollers)
    {
        this.bollers = bollers;
    }
}