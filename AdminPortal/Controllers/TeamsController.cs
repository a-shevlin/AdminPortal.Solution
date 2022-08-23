using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AdminPortal.Models;
using Newtonsoft.Json;

namespace AdminPortal.Controllers
{
  public class TeamsController : Controller
  {
    public IActionResult Index()
    {
      var allTeams = Team.GetTeams();
      return View(allTeams);
    }

    [HttpPost]
    public IActionResult Index(Team team)
    {
      Team.Post(team);
      return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Team team)
    {
      Team.Post(team);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var team = Team.GetDetails(id);
      return View(team);
    }

    public IActionResult Edit(int id)
    {
      var team = Team.GetDetails(id);
      List<Animal> animals = Animal.GetAnimals();
      ViewBag.Animals = new SelectList(animals, "AnimalId", "Name");
      List<AnimalTeam> ats = AnimalTeam.GetAnimalTeams(id);
      Dictionary<int, Animal> animalsInTeam = new Dictionary<int, Animal>();
      for (int i = 0; i < ats.Count; i++)
      {
        animalsInTeam.Add(ats[i].AnimalTeamId, animals.FirstOrDefault(a => a.AnimalId == ats[i].AnimalId)!);
      }
      ViewBag.AnimalsInTeam = animalsInTeam;
      return View(team);
    }

    [HttpPost]
    public IActionResult Details(int id, Team team)
    {
      team.TeamId = id;
      Team.Put(team);
      return RedirectToAction("Details", id);
    }

    [HttpPost]
    public IActionResult AddAnimalToTeam(int teamId, int animalId)
    {
      AnimalTeam at = Team.PostAnimalToTeam(teamId, animalId);
      return RedirectToAction("Edit", new { id = teamId });
    }

    [HttpPost]
    public IActionResult DeleteAnimalFromTeam(int teamId, int animalTeamId)
    {
      AnimalTeam.DeleteAnimalTeam(animalTeamId);
      return RedirectToAction("Edit", new { id = teamId });
    }

    public IActionResult Delete(int id)
    {
      Team.Delete(id);
      return RedirectToAction("Index");
    }
  }
}