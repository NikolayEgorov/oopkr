namespace Controllers;

using Models;
using Interfaces;
using ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    private readonly IProducts _iproducts;

    public ProductsController(IProducts products)
    {
        this._iproducts = products;
    }

    [Route("/products/index")]
    public IActionResult index()
    {
        IndexViewModels viewModels = new IndexViewModels((List<Product>)_iproducts.All);
        return View(viewModels);
    }

    [Route("/products/create")]
    public IActionResult create()
    {
        return View();
    }

    [HttpGet]
    [Route("/products/update/{id:int}")]
    public IActionResult update(int id)
    {
        Product product = (Product) this._iproducts.GetById(id);
        List<Product> products = (List<Product>) this._iproducts.All;

        return View(new UpdateViewModels(product));
    }

    [HttpPost]
    [Route("/products/update")]
    public RedirectResult update(Product product)
    {
        product = (Product) this._iproducts.SaveOne(product);
        return Redirect("/products/update/" + product.id);
    }

    [HttpPost]
    [Route("/products/delete/{id:int}")]
    public ActionResult delete(int id)
    {
        _iproducts.RemoveById(id);
        return Redirect("/products/index");
    }
}