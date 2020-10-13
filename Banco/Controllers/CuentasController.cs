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
    public class CuentasController : Controller
    {
        private BancoEntities db = new BancoEntities();

        // GET: Cuentas
        public ActionResult Index()
        {
            var cuenta = db.Cuenta.Include(c => c.Cliente).Include(c => c.Estado).Include(c => c.TipoCuenta).Include(c => c.TipoMoneda);
            return View(cuenta.ToList());
        }

        // GET: Cuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // GET: Cuentas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "IdCliente", "FullName");
            ViewBag.EstadoId = new SelectList(db.Estado, "EstadoId", "Descripcion");
            ViewBag.TipoCuentaId = new SelectList(db.TipoCuenta, "TipoCuentaId", "Descripcion");
            ViewBag.TipoMonedaId = new SelectList(db.TipoMoneda, "TipoMonedaId", "Descripcion");
            return View();
        }

        // POST: Cuentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CuentaId,TipoMonedaId,Saldo,EstadoId,TipoCuentaId,ClienteId,NumCuenta")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Cuenta.Add(cuenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "IdCliente", "FullName", cuenta.ClienteId);
            ViewBag.EstadoId = new SelectList(db.Estado, "EstadoId", "Descripcion", cuenta.EstadoId);
            ViewBag.TipoCuentaId = new SelectList(db.TipoCuenta, "TipoCuentaId", "Descripcion", cuenta.TipoCuentaId);
            ViewBag.TipoMonedaId = new SelectList(db.TipoMoneda, "TipoMonedaId", "Descripcion", cuenta.TipoMonedaId);
            return View(cuenta);
        }

        // GET: Cuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "IdCliente", "FullName", cuenta.ClienteId);
            ViewBag.EstadoId = new SelectList(db.Estado, "EstadoId", "Descripcion", cuenta.EstadoId);
            ViewBag.TipoCuentaId = new SelectList(db.TipoCuenta, "TipoCuentaId", "Descripcion", cuenta.TipoCuentaId);
            ViewBag.TipoMonedaId = new SelectList(db.TipoMoneda, "TipoMonedaId", "Descripcion", cuenta.TipoMonedaId);
            return View(cuenta);
        }

        // POST: Cuentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CuentaId,TipoMonedaId,Saldo,EstadoId,TipoCuentaId,ClienteId,NumCuenta")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "IdCliente", "FullName", cuenta.ClienteId);
            ViewBag.EstadoId = new SelectList(db.Estado, "EstadoId", "Descripcion", cuenta.EstadoId);
            ViewBag.TipoCuentaId = new SelectList(db.TipoCuenta, "TipoCuentaId", "Descripcion", cuenta.TipoCuentaId);
            ViewBag.TipoMonedaId = new SelectList(db.TipoMoneda, "TipoMonedaId", "Descripcion", cuenta.TipoMonedaId);
            return View(cuenta);
        }

        // GET: Cuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // POST: Cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuenta cuenta = db.Cuenta.Find(id);
            db.Cuenta.Remove(cuenta);
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
