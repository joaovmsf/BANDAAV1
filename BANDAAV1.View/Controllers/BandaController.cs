using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BANDAAV1.Model;

namespace BANDAAV1.View.Controllers
{
    public class BandaController : Controller
    {
        // GET: BandaController
        BANDASContext db;
        public BandaController()
        {
            db = new BANDASContext();
        }
        public ActionResult Index()
        {
            List<Tbbanda> oLista = db.Tbbanda.ToList(); 
            return View(oLista);
        }

        // GET: BandaController/Details/5
        public ActionResult Details(int id)
        {
            Tbbanda oBan = db.Tbbanda.Find(id);
            return View(oBan);
        }

        // GET: BandaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BandaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbbanda oBan)
        {
            db.Tbbanda.Add(oBan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: BandaController/Edit/5
        public ActionResult Edit(int id)
        {
            Tbbanda oBan = db.Tbbanda.Find(id);
            return View(oBan);
        }

        // POST: BandaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tbbanda oBan)
        {
            var oBanBanco = db.Tbbanda.Find(id);
            oBanBanco.BandaNome = oBan.BandaNome;
            oBanBanco.Bandagenero = oBan.Bandagenero;
            db.Entry(oBanBanco).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: BandaController/Delete/5
        public ActionResult Delete(int id)
        {
            Tbbanda oBan = db.Tbbanda.Find(id);
            return View(oBan);
        }

        // POST: BandaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Tbbanda oBan)
        {
            var oBanBanco = db.Tbbanda.Find(id);
            oBanBanco.BandaNome = oBan.BandaNome;
            oBanBanco.Bandagenero = oBan.Bandagenero;
            db.Entry(oBanBanco).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
