using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
  private readonly IUnitOfWork _uow;
  public CategoryController(IUnitOfWork uow)
  {
    _uow = uow;
  }
  public IActionResult Index()
  {
    var objCategoryList = _uow.Category.GetAll();
    return View(objCategoryList);
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Create(Category category)
  {
    if (ModelState.IsValid)
    {
      _uow.Category.Add(category);
      _uow.Save();
      TempData["success"] = "Category created successfully";
      return RedirectToAction("Index");
    }
    return View();
  }

  public IActionResult Edit(int? id)
  {
    if (id == null || id == 0)
      return NotFound();

    var category = _uow.Category.Get(x => x.Id == id);

    if (category == null)
      return NotFound();

    return View(category);
  }

  [HttpPost]
  public IActionResult Edit(Category category)
  {
    if (ModelState.IsValid)
    {
      _uow.Category.Update(category);
      _uow.Save();
      TempData["success"] = "Category updated successfully";
      return RedirectToAction("Index");
    }
    return View();
  }

  public IActionResult Delete(int? id)
  {
    if (id == null || id == 0)
      return NotFound();

    var category = _uow.Category.Get(x => x.Id == id);

    if (category == null)
      return NotFound();

    return View(category);
  }

  [HttpPost, ActionName("Delete")]
  public IActionResult DeletePOST(int? id)
  {
    var category = _uow.Category.Get(x => x.Id == id);

    if (category == null)
      return NotFound();

    _uow.Category.Remove(category);
    _uow.Save();
    TempData["success"] = "Category deleted successfully";
    return RedirectToAction("Index");
  }
}
