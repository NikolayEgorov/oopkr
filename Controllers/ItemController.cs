namespace Controllers;

using Models;
using Interfaces;
using ViewModels.Items;
using Microsoft.AspNetCore.Mvc;

public class ItemsController : Controller
{
    private readonly IItems _items;
    private readonly IProducts _iproducts;

    public ItemsController(IItems items, IProducts products)
    {
        this._items = items;
        this._iproducts = products;
    }

    [Route("/items/index")]
    public IActionResult index()
    {
        IndexViewModels viewModels = new IndexViewModels(_items.All);
        return View(viewModels);
    }

    [Route("/items/create")]
    public IActionResult create()
    {
        List<Product> products = this._iproducts.All;
        return View(new UpdateViewModels(new Item(), products));
    }

    [HttpGet]
    [Route("/items/update/{id:int}")]
    public IActionResult update(int id)
    {
        Item item = this._items.GetById(id);
        List<Product> products = this._iproducts.All;

        return View(new UpdateViewModels(item, products));
    }

    [HttpPost]
    [Route("/items/update")]
    public RedirectResult update(Item item, List<Product> products)
    {
        item = this._items.SaveOne(item);

        foreach (string productId in Helpers.ParseMultipleSelectValue(Request.Form, "products")) {
            products.Add(this._iproducts.GetById(Int32.Parse(productId)));
        }
        item.products = products;

        this._items.SaveProducts(item);
        return Redirect("/items/index");
    }

    [HttpPost]
    [Route("/items/delete/{id:int}")]
    public ActionResult delete(int id)
    {
        this._items.RemoveById(id);
        return Redirect("/items/index");
    }
}