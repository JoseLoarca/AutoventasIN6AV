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
    public class AutomovilController : Controller
    {
        private DB_AUTOVENTAS db = new DB_AUTOVENTAS();

        // GET: Automovil
        public ActionResult Index(String search, String searchFeatures)
        {
            var automovil = db.automovil.Include(a => a.categoria).Include(a => a.combustible).Include(a => a.estado).Include(a => a.marca).Include(a => a.transmision);

            if(!String.IsNullOrEmpty(search))
            {
                automovil = automovil.Where(a => a.modelo.Contains(search) || a.marca.nombre.Contains(search) );
            
            }

            if (!String.IsNullOrEmpty(searchFeatures))
            {
                automovil = automovil.Where(a => a.combustible.nombre.Contains(searchFeatures) || a.categoria.nombre.Contains(searchFeatures)
                    || a.estado.nombre.Contains(searchFeatures) || a.transmision.nombre.Contains(searchFeatures));
            }

            return View(automovil.ToList());
        }

        // GET: Automovil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // GET: Automovil/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.categoria, "idCategoria", "nombre");
            ViewBag.idCombustible = new SelectList(db.combustible, "idCombustible", "nombre");
            ViewBag.idEstado = new SelectList(db.estado, "idEstado", "nombre");
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre");
            ViewBag.idTransmision = new SelectList(db.transmision, "idTransmision", "nombre");
            return View();
        }

        // POST: Automovil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAutomovil,modelo,año,color,precio,informacionExtra,idMarca,idCategoria,idCombustible,idEstado,idTransmision")] Automovil automovil, HttpPostedFileBase archivo)
        {
            if (ModelState.IsValid)
            {
                if(archivo!=null && archivo.ContentLength>0){
                    var imagen = new Archivo{
                        nombre = System.IO.Path.GetFileName(archivo.FileName),
                        tipo = FileType.Imagen,
                        ContentType=archivo.ContentType
                    };
                    using(var reader = new System.IO.BinaryReader(archivo.InputStream)){
                        imagen.contenido= reader.ReadBytes(archivo.ContentLength);
                    };
                    automovil.archivos = new List<Archivo> { imagen };
                }
                db.automovil.Add(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.categoria, "idCategoria", "nombre", automovil.idCategoria);
            ViewBag.idCombustible = new SelectList(db.combustible, "idCombustible", "nombre", automovil.idCombustible);
            ViewBag.idEstado = new SelectList(db.estado, "idEstado", "nombre", automovil.idEstado);
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre", automovil.idMarca);
            ViewBag.idTransmision = new SelectList(db.transmision, "idTransmision", "nombre", automovil.idTransmision);
            return View(automovil);
        }

        // GET: Automovil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.categoria, "idCategoria", "nombre", automovil.idCategoria);
            ViewBag.idCombustible = new SelectList(db.combustible, "idCombustible", "nombre", automovil.idCombustible);
            ViewBag.idEstado = new SelectList(db.estado, "idEstado", "nombre", automovil.idEstado);
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre", automovil.idMarca);
            ViewBag.idTransmision = new SelectList(db.transmision, "idTransmision", "nombre", automovil.idTransmision);
            return View(automovil);
        }

        // POST: Automovil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Automovil automovil, HttpPostedFileBase archivo)
        {
            if(automovil==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            if (TryUpdateModel(automovil, "", new string[] { "idAutomovil, modelo, año, color, precio, informacionExtra, idMarca, idCategoria, idCombustible, idEstado, idTransmision"}))
            {
                try
                {
                    if(archivo != null && archivo.ContentLength > 0)
                    {
                        if(automovil.archivos.Any(i => i.tipo == FileType.Imagen))
                        {
                            db.archivo.Remove(automovil.archivos.First(i => i.tipo == FileType.Imagen));
                        }
                        var imagen = new Archivo
                        {
                            nombre = System.IO.Path.GetFileName(archivo.FileName),
                            tipo = FileType.Imagen,
                            ContentType = archivo.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(archivo.InputStream))
                        {
                            imagen.contenido = reader.ReadBytes(archivo.ContentLength);
                        }
                        automovil.archivos = new List<Archivo> { imagen };
                    }
                    db.Entry(automovil).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }

                catch(RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.)
                    ModelState.AddModelError("", "Unable to save changes. Try again and if the problem persists, see your system administrator.");
                }
            }
            ViewBag.idCategoria = new SelectList(db.categoria, "idCategoria", "nombre", automovil.idCategoria);
            ViewBag.idCombustible = new SelectList(db.combustible, "idCombustible", "nombre", automovil.idCombustible);
            ViewBag.idEstado = new SelectList(db.estado, "idEstado", "nombre", automovil.idEstado);
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre", automovil.idMarca);
            ViewBag.idTransmision = new SelectList(db.transmision, "idTransmision", "nombre", automovil.idTransmision);
            return View(automovil);
        }

        // GET: Automovil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // POST: Automovil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automovil automovil = db.automovil.Find(id);
            db.automovil.Remove(automovil);
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
