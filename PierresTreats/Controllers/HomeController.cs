using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;

namespace PierresTreats.Controllers 
{
    public class HomeController : Controller
    {
      private readonly PierresTreatsContext _db;

      public HomeController(PierresTreatsContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        List<Treat> treats = _db.Treats.ToList();
        List<Flavor> flavors = _db.Flavors.ToList();
        ViewBag.treats = treats;
        ViewBag.flavors = flavors;
        return View();
      }

    }
}