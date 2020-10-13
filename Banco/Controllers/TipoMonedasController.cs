using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Banco.Models.Data;

namespace Banco.Controllers
{
    public class TipoMonedasController : Controller
    {
        private BancoEntities db = new BancoEntities();

        // GET: TipoMonedas
        public ActionResult Index()
        {
            return View(db.TipoMoneda.ToList());
        }

        // GET: TipoMonedas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMoneda tipoMoneda = db.TipoMoneda.Find(id);
            if (tipoMoneda == null)
            {
                return HttpNotFound();
            }
            return View(tipoMoneda);
        }

        // GET: TipoMonedas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoMonedas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoMonedaId,Descripcion")] TipoMoneda tipoMoneda)
        {
            if (ModelState.IsValid)
            {
                db.TipoMoneda.Add(tipoMoneda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoMoneda);
        }

        // GET: TipoMonedas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMoneda tipoMoneda = db.TipoMoneda.Find(id);
            if (tipoMoneda == null)
            {
                return HttpNotFound();
            }
            return View(tipoMoneda);
        }

        // POST: TipoMonedas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoMonedaId,Descripcion")] TipoMoneda tipoMoneda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoMoneda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoMoneda);
        }

        // GET: TipoMonedas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMoneda tipoMoneda = db.TipoMoneda.Find(id);
            if (tipoMoneda == null)
            {
                return HttpNotFound();
            }
            return View(tipoMoneda);
        }

        // POST: TipoMonedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoMoneda tipoMoneda = db.TipoMoneda.Find(id);
            db.TipoMoneda.Remove(tipoMoneda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
