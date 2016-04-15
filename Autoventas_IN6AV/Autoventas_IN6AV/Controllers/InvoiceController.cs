using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Autoventas_IN6AV.Models;
using System.Data.Entity.Infrastructure;

namespace Autoventas_IN6AV.Controllers
{
    public class InvoiceController : Controller
    {
        private DB_AUTOVENTAS db = new DB_AUTOVENTAS();
   
        // GET: Invoice
        public ActionResult ImpresionReservacion()
        {
            var reservacion = db.reservacion.Include(r => r.automovil).Include(r => r.usuario);
            return View(reservacion.ToList());
        }

        public ActionResult ImpresionCotizacion(int? idAutomovil)
        {
            if (idAutomovil == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.automovil.Find(idAutomovil);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }
    }
}