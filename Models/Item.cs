namespace Models;

public class Item : Base
{
    public string title { get; set; } = String.Empty;
    public int price { get; set; } = 0;

    public List<ItemProduct> itemProducts { get; set; } = new List<ItemProduct>();
    public List<Product> products { get; set; } = new List<Product>();

    public List<OrderItem> orderItems { get; set; } = new List<OrderItem>();
    public List<Order> orders { get; set; } = new List<Order>();

    public Item() {}
}