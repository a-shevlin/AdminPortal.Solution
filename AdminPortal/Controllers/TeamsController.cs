using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
      return View(team);
    }

    [HttpPost]
    public IActionResult Details(int id, Team team)
    {
      team.TeamId = id;
      Team.Put(team);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Team.Delete(id);
      return RedirectToAction("Index");
    }
  }
}