using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;

namespace PierresTreats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierresTreatsContext _db;

    public TreatsController(PierresTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Treat> model = _db.Treats.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      if (!ModelState.IsValid)
      {
        return View(treat);
      }
      else
      {
        _db.Treats.Add(treat);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
      }
    }

    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
        .Include(treat => treat.JoinEntities)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    public ActionResult AddFlavor(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      List<Flavor> flavors = _db.Flavors.ToList();
      ViewBag.flavors = flavors;
      ViewBag.flavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int flavorId)
    {
      #nullable enable
      TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => (join.FlavorId == flavorId && join.TreatId == treat.TreatId));
      #nullable disable
      if (joinEntity == null && flavorId != 0)
      {
        _db.TreatFlavors.Add(new TreatFlavor() { FlavorId = flavorId, TreatId = treat.TreatId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = treat.TreatId });
    }

    [HttpGet("/treats/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats
        .Include(treat => treat.JoinEntities)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost("/treats/{id}/edit")]
    public ActionResult Edit(Treat treat)
    {
      _db.Treats.Update(treat);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = treat.TreatId });
    }

    public ActionResult DeleteJoin(int id)
    {
      TreatFlavor joinEntity = _db.TreatFlavors.FirstOrDefault(entity => entity.TreatFlavorId == id);
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == joinEntity.FlavorId);
      ViewBag.flavorName = thisFlavor.Name;
      return View(joinEntity);
    }

    [HttpPost, ActionName("DeleteJoin")]
    public ActionResult DeleteJoinConfirm(int id)
    {
      TreatFlavor joinEntity = _db.TreatFlavors.FirstOrDefault(entity => entity.TreatFlavorId == id);
      _db.TreatFlavors.Remove(joinEntity);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = joinEntity.TreatId });
    }

    [HttpGet("/treats/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost("/treats/{id}/delete")]
    public ActionResult DeleteConfirm(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}