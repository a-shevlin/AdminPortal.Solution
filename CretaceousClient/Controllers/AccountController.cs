using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminPortal.Models;

namespace AdminPortal.Controllers
{
  public class AccountController : Controller
  {
    public IActionResult Index(User user)
    {
      return View();
    }
  }
}