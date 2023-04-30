namespace Controllers;

using Models;
using Interfaces;
using ViewModels.Plants;
using Microsoft.AspNetCore.Mvc;

public class PlantsController : Controller
{
    // public PlantsController()
    // {
    // }

    // [Route("/plants/index")]
    // public IActionResult index()
    // {
    //     IndexViewModels viewModels = new IndexViewModels(_items.All);
    //     return View(viewModels);
    // }

    // [Route("/plants/create")]
    // public IActionResult create()
    // {
    //     List<Product> products = this._iproducts.All;
    //     return View(new UpdateViewModels(new Item(), products));
    // }

    // [HttpGet]
    // [Route("/plants/update/{id:int}")]
    // public IActionResult update(int id)
    // {
    //     Item item = this._items.GetById(id);
    //     List<Product> products = this._iproducts.All;

    //     return View(new UpdateViewModels(item, products));
    // }

    // [HttpPost]
    // [Route("/plants/update")]
    // public RedirectResult update(Item item, List<Product> products)
    // {
    //     item = this._items.SaveOne(item);

    //     foreach (string productId in Helpers.ParseMultipleSelectValue(Request.Form, "products")) {
    //         products.Add(this._iproducts.GetById(Int32.Parse(productId)));
    //     }
    //     item.products = products;

    //     this._items.SaveProducts(item);
    //     return Redirect("/items/index");
    // }

    // [HttpPost]
    // [Route("/plants/delete/{id:int}")]
    // public ActionResult delete(int id)
    // {
    //     this._items.RemoveById(id);
    //     return Redirect("/items/index");
    // }
}