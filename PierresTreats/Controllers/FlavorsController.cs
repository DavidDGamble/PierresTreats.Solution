using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;

namespace PierresTreats.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly PierresTreatsContext _db;

    public FlavorsController(PierresTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Flavor> model = _db.Flavors.ToList();
      return View(model);
    }

    [Authorize(Roles = "admin")]
    public ActionResult Create()
    {
      return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      if (!ModelState.IsValid)
      {
        return View(flavor);
      }
      else
      {
        _db.Flavors.Add(flavor);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
      }
    }

    public ActionResult Details(int id)
    {
      Flavor thisFlavor = _db.Flavors
        .Include(flavor => flavor.JoinEntities)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [Authorize(Roles = "admin")]
    public ActionResult AddTreat(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      List<Treat> treats = _db.Treats.ToList();
      ViewBag.treats = treats;
      ViewBag.treatId = new SelectList(_db.Treats, "TreatId", "Name");
      return View(thisFlavor);
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int treatId)
    {
      #nullable enable
      TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => (join.TreatId == treatId && join.FlavorId == flavor.FlavorId));
      #nullable disable
      if (joinEntity == null && treatId != 0)
      {
        _db.TreatFlavors.Add(new TreatFlavor() { TreatId = treatId, FlavorId = flavor.FlavorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    [Authorize(Roles = "admin")]
    [HttpGet("/flavors/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Flavor thisFlavor = _db.Flavors
        .Include(flavor => flavor.JoinEntities)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [Authorize(Roles = "admin")]
    [HttpPost("/flavors/{id}/edit")]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Flavors.Update(flavor);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    [Authorize(Roles = "admin")]
    public ActionResult DeleteJoin(int id)
    {
      TreatFlavor joinEntity = _db.TreatFlavors.FirstOrDefault(entity => entity.TreatFlavorId == id);
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == joinEntity.TreatId);
      ViewBag.treatName = thisTreat.Name;
      return View(joinEntity);
    }

    [Authorize(Roles = "admin")]
    [HttpPost, ActionName("DeleteJoin")]
    public ActionResult DeleteJoinConfirm(int id)
    {
      TreatFlavor joinEntity = _db.TreatFlavors.FirstOrDefault(entity => entity.TreatFlavorId == id);
      _db.TreatFlavors.Remove(joinEntity);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = joinEntity.FlavorId });
    }

    [Authorize(Roles = "admin")]
    [HttpGet("/flavors/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [Authorize(Roles = "admin")]
    [HttpPost("/flavors/{id}/delete")]
    public ActionResult DeleteConfirm(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}