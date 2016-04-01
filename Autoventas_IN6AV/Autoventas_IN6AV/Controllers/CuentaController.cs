using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autoventas_IN6AV.Models;

namespace Autoventas_IN6AV.Controllers
{
    public class CuentaController : Controller
    {
        public DB_AUTOVENTAS db = new DB_AUTOVENTAS();

        // GET: /Cuenta/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            var usr = db.usuario.FirstOrDefault(u => u.username==usuario.username && u.password==usuario.password);
            if(usr!=null){
                Session["nombreUsuario"] = usr.nombre;
                Session["idUsuario"] = usr.idUsuario;
                Session["idRol"] = usr.rol;
                return VerificarSesion();
            }
            else
            {
                ModelState.AddModelError("", "Nombre de Usuario y/o Contraseña incorrectos.");
            }
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            if(ModelState.IsValid){
                var rol = db.rol.FirstOrDefault(r => r.idRol == 2);
                usuario.rol = rol;
                db.usuario.Add(usuario);
                db.SaveChanges();
                ViewBag.mensaje = "El usuario "+ usuario.nombre +" ha sido registrado en nuestra base de datos!";
            }
            return View();
        }

        public ActionResult VerificarSesion()
        {
            if(Session["idUsuario"]!=null){
                return RedirectToAction("../Home/Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("idUsuario");
            Session.Remove("nombreUsuario");
            return RedirectToAction("Login");
        }
	}
}