using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class ProductController : Controller
  {
    private readonly IUnitOfWork _uow;

    public ProductController(IUnitOfWork uow)
    {
      _uow = uow;
    }

    public IActionResult Index()
    {
      var products = _uow.Product.GetAll();
      return View(products);
    }

    public IActionResult Create()
    {
      ProductVM productVM = new()
      {
        Product = new Product(),
        CategoryList = _uow.Category.GetAll()
        .Select(select => new SelectListItem
        {
          Text = select.Name,
          Value = select.Id.ToString(),
        })
      };
      return View(productVM);
    }

    [HttpPost]
    public IActionResult Create(ProductVM productVM)
    {
      if (ModelState.IsValid)
      {
        _uow.Product.Add(productVM.Product);
        _uow.Save();
        TempData["success"] = "Product created successfully";
        return RedirectToAction("Index");
      }
      else
      {
        productVM.CategoryList = _uow.Category.GetAll()
        .Select(select => new SelectListItem
        {
          Text = select.Name,
          Value = select.Id.ToString(),
        });
        return View(productVM);
      }
    }

    public IActionResult Edit(int? id)
    {
      if (id == null || id == 0)
        return NotFound();

      var product = _uow.Product.Get(x => x.Id == id);

      if (product == null)
        return NotFound();

      return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
      if (ModelState.IsValid)
      {
        _uow.Product.Update(product);
        _uow.Save();
        TempData["success"] = "Product updated successfully";
        return RedirectToAction("Index");
      }

      return View();
    }

    public IActionResult Delete(int? id)
    {
      if (id == null || id == 0)
        return NotFound();

      var product = _uow.Product.Get(x => x.Id == id);

      if (product == null)
        return NotFound();

      return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
      if (id == null || id == 0)
        return NotFound();

      var product = _uow.Product.Get(x => x.Id == id);

      if (product == null)
        return NotFound();

      _uow.Product.Remove(product);
      _uow.Save();
      return RedirectToAction("Index");
    }
  }
}