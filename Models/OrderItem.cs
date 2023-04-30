namespace Models;

public class OrderItem
{
    public int id { get; set; }

    public int orderid { get; set; }
    public int itemid { get; set; }

    public Order order { get; set; } = new Order();
    public Item item { get; set; } = new Item();
}