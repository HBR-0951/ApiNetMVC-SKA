using System.Diagnostics;
using ApiNetMVC_SKA.core.Services.ApiProduct;
using Microsoft.AspNetCore.Mvc;
using ApiNetMVC_SKA.Models;

namespace ApiNetMVC_SKA.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}