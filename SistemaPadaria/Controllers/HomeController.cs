using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaPadaria.Models;

namespace SistemaPadaria.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

   
}
