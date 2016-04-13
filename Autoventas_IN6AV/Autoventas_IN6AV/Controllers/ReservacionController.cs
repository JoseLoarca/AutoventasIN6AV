using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Autoventas_IN6AV.Models;

namespace Autoventas_IN6AV.Controllers
{
    public class ReservacionController : Controller
    {
        private DB_AUTOVENTAS db = new DB_AUTOVENTAS();

        // GET: Reservacion
        public ActionResult Index()
        {
            var reservacion = db.reservacion.Include(r => r.automovil).Include(r => r.usuario);
            return View(reservacion.ToList());
        }

        // GET: Reservacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservacion reservacion = db.reservacion.Find(id);
            if (reservacion == null)
            {
                return HttpNotFound();
            }
            return View(reservacion);
        }

        // GET: Reservacion/Create
        public ActionResult Create()
        {
            ViewBag.idAutomovil = new SelectList(db.automovil, "idAutomovil", "modelo");
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Reservacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idReservacion,fecha,idUsuario,idAutomovil")] Reservacion reservacion)
        {
            if (ModelState.IsValid)
            {
                db.reservacion.Add(reservacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAutomovil = new SelectList(db.automovil, "idAutomovil", "modelo", reservacion.idAutomovil);
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "nombre", reservacion.idUsuario);
            return View(reservacion);
        }

        // GET: Reservacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservacion reservacion = db.reservacion.Find(id);
            if (reservacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAutomovil = new SelectList(db.automovil, "idAutomovil", "modelo", reservacion.idAutomovil);
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "nombre", reservacion.idUsuario);
            return View(reservacion);
        }

        // POST: Reservacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idReservacion,fecha,idUsuario,idAutomovil")] Reservacion reservacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAutomovil = new SelectList(db.automovil, "idAutomovil", "modelo", reservacion.idAutomovil);
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "nombre", reservacion.idUsuario);
            return View(reservacion);
        }

        // GET: Reservacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservacion reservacion = db.reservacion.Find(id);
            if (reservacion == null)
            {
                return HttpNotFound();
            }
            return View(reservacion);
        }

        // POST: Reservacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservacion reservacion = db.reservacion.Find(id);
            db.reservacion.Remove(reservacion);
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
