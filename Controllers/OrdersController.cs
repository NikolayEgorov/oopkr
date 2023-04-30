namespace Controllers;

using Models;
using Interfaces;
using ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;

public class OrdersController : Controller
{
    private readonly IOrders _iorders;
    private readonly IItems _items;
    private readonly IUsers _iusers;

    public OrdersController(IOrders iOrders, IItems iItems, IUsers iUsers)
    {
        this._iorders = iOrders;
        this._items = iItems;
        this._iusers = iUsers;
    }

    [Route("/orders/index")]
    public IActionResult index()
    {
        IndexViewModels viewModels = new IndexViewModels(_iorders.All);
        return View(viewModels);
    }

    [Route("/orders/create")]
    public IActionResult create()
    {
        List<Item> items = this._items.All;
        List<User> users = this._iusers.All;
        return View(new UpdateViewModels(new Order(), items, users));
    }

    [HttpGet]
    [Route("/orders/update/{id:int}")]
    public IActionResult update(int id)
    {
        Order order = this._iorders.GetById(id);
        List<Item> items = this._items.All;
        List<User> users = this._iusers.All;

        return View(new UpdateViewModels(order, items, users));
    }

    [HttpPost]
    [Route("/orders/update")]
    public RedirectResult update(Order order, List<Item> items)
    {
        int userid = Int32.Parse(Helpers.GetFormData(Request.Form, "userid").Value);    

        order.user = this._iusers.GetById(userid);
        order = this._iorders.SaveOne(order);

        foreach (string itemId in Helpers.ParseMultipleSelectValue(Request.Form, "itemids")) {
            items.Add(this._items.GetById(Int32.Parse(itemId)));
        }
        order.items = items;

        this._iorders.SaveItems(order);
        return Redirect("/orders/index");
    }

    [HttpPost]
    [Route("/orders/delete/{id:int}")]
    public ActionResult delete(int id)
    {
        this._iorders.RemoveById(id);
        return Redirect("/orders/index");
    }
}