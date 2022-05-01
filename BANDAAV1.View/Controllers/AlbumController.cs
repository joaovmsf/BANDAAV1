using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BANDAAV1.Model;

namespace BANDAAV1.View.Controllers
{
    public class AlbumController : Controller
    {
        // GET: AlbumController
        BANDASContext db;
        public AlbumController()
        {
            db = new BANDASContext();
        }
        public ActionResult Index()
        {
            List<Tbalbum> oLista = db.Tbalbum.ToList();
            return View(oLista);
        }

        // GET: AlbumController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlbumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlbumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbalbum oAlb)
        {
            db.Tbalbum.Add(oAlb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: AlbumController/Edit/5
        public ActionResult Edit(int id)
        {
            Tbalbum oAlb = db.Tbalbum.Find(id);
            return View(oAlb);
        }

        // POST: AlbumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tbalbum oAlb)
        {
            var oAlbBanco = db.Tbalbum.Find(id);
            oAlbBanco.AlbumNome = oAlb.AlbumNome;
            db.Entry(oAlbBanco).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: AlbumController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlbumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
