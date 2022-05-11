using System.Linq;
using System.Collections.Generic;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Controllers
{
  public class EmployeeManagerController : Controller
  {
    private AppDbContext db = null;
    public EmployeeManagerController(AppDbContext db)
    {
      this.db = db;
    }

    public IActionResult List()
    {
      List<Employee> model = (from e in db.Employees
                                                  orderby e.EmployeeID
                                                  select e).ToList();

              return   View(model);
    }
[HttpGet]
    public IActionResult Insert()
    {
      FillCountries();
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Insert(Employee model)
    {
      if (ModelState.IsValid)
      {
        db.Employees.Add(model);
        db.SaveChanges();
        ViewBag.Message = "Employee added successfully";
      }
      return View(model);
    }
    [HttpGet]
    public IActionResult Update(int id)
    {
      FillCountries();
      var model = db.Employees.Find(id);
      return View(model);
    }

      [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Update(Employee model)
    {
      if (ModelState.IsValid)
      {
        db.Employees.Update(model);
        db.SaveChanges();
        ViewBag.Message = "Employee Updated successfully";
      }
      return View(model);
    }

    [HttpDelete]
    [ActionName("Delete")]
    public IActionResult ConfirmDelete(int id)
    {
      var model = db. Employees.Find(id);
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
      var model = db.Employees.Find(id);
      db.Employees.Remove(model);
      db.SaveChanges();
      TempData["Message"] = "Employee Deleted Successfully";
      return RedirectToAction("List");
    }




    private void FillCountries()
    {
      List<SelectListItem> listOfCountries = (from c in db.Employees 
                                                                        select new SelectListItem()
      {
                                                                           Text = c.Country,
                                                                            Value = c.Country
                                                                            }).Distinct().ToList();
              ViewBag.Countries = listOfCountries;
      }
    }
  }
