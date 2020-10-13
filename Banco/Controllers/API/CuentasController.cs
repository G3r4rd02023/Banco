using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Banco.Models.Data;

namespace Banco.Controllers.API
{
    public class CuentasController : ApiController
    {
        private BancoEntities db = new BancoEntities();

        // GET: api/Cuentas
        public IQueryable<Cuenta> GetCuenta()
        {
            return db.Cuenta;
        }

        // GET: api/Cuentas/5
        [ResponseType(typeof(Cuenta))]
        public IHttpActionResult GetCuenta(int id)
        {
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return Ok(cuenta);
        }

        // PUT: api/Cuentas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuenta(int id, Cuenta cuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuenta.CuentaId)
            {
                return BadRequest();
            }

            db.Entry(cuenta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cuentas
        [ResponseType(typeof(Cuenta))]
        public IHttpActionResult PostCuenta(Cuenta cuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cuenta.Add(cuenta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cuenta.CuentaId }, cuenta);
        }

        // DELETE: api/Cuentas/5
        [ResponseType(typeof(Cuenta))]
        public IHttpActionResult DeleteCuenta(int id)
        {
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            db.Cuenta.Remove(cuenta);
            db.SaveChanges();

            return Ok(cuenta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CuentaExists(int id)
        {
            return db.Cuenta.Count(e => e.CuentaId == id) > 0;
        }
    }
}