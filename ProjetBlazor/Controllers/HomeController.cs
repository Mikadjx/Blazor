using Microsoft.AspNetCore.Mvc;
using AspNetPME.Data;

namespace AspNetPME.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _db;

    public HomeController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var products = _db.Products.ToList();
        return View(products);
    }
}