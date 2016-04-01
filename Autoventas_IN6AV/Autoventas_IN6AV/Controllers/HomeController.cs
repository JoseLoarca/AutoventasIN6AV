using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autoventas_IN6AV.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contacto()
        {
            ViewBag.Info = "Si tiene una consulta, no dude en visitarnos o llamarnos.";
            return View();
        }
	}
}