using Microsoft.AspNetCore.Mvc;
using ProjetBlazor.Data;        // ← ProjetBlazor pas AspNetPME

namespace ProjetBlazor.Controllers;

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