using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminPortal.Models;
using AdminPortal.ViewModels;

namespace AdminPortal.Controllers
{
  public class AccountController : Controller
  {
    public IActionResult Index()
    {
      if (TempData["response"] != null)
      {
        ViewBag.Response = TempData["response"];
      }
      return View();
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel user)
    {
      var response = await ApiHelper.LogIn(user);
      TempData["response"] = response;
      return RedirectToAction("Index");
    }
  }
}