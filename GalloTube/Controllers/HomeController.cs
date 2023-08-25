using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GalloTube.Models;
using GalloTube.Data;
using Microsoft.EntityFrameworkCore;

namespace GalloTube.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var videos = _context.Videos.Include(m => m.Tags).ThenInclude(g => g.Tag).ToList();
        return View(videos);
    }
    public IActionResult Video(int? id)
    {
        var Video = _context.Videos
            .Where(m => m.Id == id)
            .Include(m => m.Tags)
            .ThenInclude(g => g.Tag)
            .SingleOrDefault();
        return View(Video);
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

