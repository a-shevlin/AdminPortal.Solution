using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminPortal.Models;

namespace AdminPortal.Controllers
{
  public class AnimalsController : Controller
  {
    public IActionResult Index()
    {
      var allAnimals = Animal.GetAnimals();
      return View(allAnimals);
    }

    [HttpPost]
    public IActionResult Index(Animal animal)
    {
      Animal.Post(animal);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var animal = Animal.GetDetails(id);
      return View(animal);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Animal animal)
    {
      Animal.Post(animal);
      return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
      var animal = Animal.GetDetails(id);
      return View(animal);
    }

    [HttpPost]
    public IActionResult Edit(Animal animal)
    {
      int id = animal.AnimalId;
      Animal.Put(animal);
      return RedirectToAction("Details", new { id = id });
    }

    public IActionResult Delete(int id)
    {
      var animal = Animal.GetDetails(id);
      return View(animal);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult Deleted(int id)
    {
      Animal.Delete(id);
      return RedirectToAction("Index");
    }
  }
}