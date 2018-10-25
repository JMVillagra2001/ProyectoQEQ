using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ2.Models;

namespace QEQ2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2(Usuarios x)
        {
            if (ModelState.IsValid)
            {
                bool a = BD.Registro(x);
                if (a)
                {
                    return RedirectToAction("Index");
                }
                return View("Index");
            }
            else
            {
                return View("Form");
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult JuegoHome()
        {
            return View();
        }
        public ActionResult Iniciarsesion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Iniciarsesionexitoso(string Nombre, string Contraseña)
        {
            if (ModelState.IsValid)
            {
                bool a = BD.OtroLogin(Nombre, Contraseña);
                if (a)
                {
                    return View("Juego");
                }
                return View("Iniciarsesion");
            }
            else
            {
                return View("Iniciarsesion");
            }
        }
        public ActionResult Juego()
        {
            return View();
        }
    }
}