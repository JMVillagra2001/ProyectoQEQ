using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ2.Models;

namespace QEQ2.Controllers
{
    public class BackOfficeController : Controller
{       public int ValidarDato()
        {
            int val = 0;
            if((Usuarios)Session["Nombre"]==null)
            {
                val = 1;
            }
            if ((Usuarios)Session["Nombre"] != null &&(bool)Session ["Admin"]!= true)
            {
                val = 2;
            }
            return val;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrarse()
        {
            return View("Form");
        }

        [HttpPost]
        public ActionResult RegistroExistoso(Usuarios x)
        {
            if(ModelState.IsValid)
            {
                bool a = BD.Registro(x);
                if (a)
                {
                    return View("Index");
                }
                return View("Form");
            }
            else
            {
                return View("Index");
            }
        }
        public ActionResult Login ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginExitoso (Usuarios x)
        {
            if (ModelState.IsValid)
            {
                bool a = BD.Login(x);
                if (a)
                {
                    Session["Usuario"] = x.Nombre;
                    return View("Login");
                }

                return View("Login");
            }
            else
            {
                return View("HomeBackOffice");
            }

        }
        public ActionResult HomeBackOffice(Usuarios x)
        {
            if(Session["Usuario"]!= null)
            {
                return View("HomeBackOffice");
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult LogOut ()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Categoria()
        {
            List<Categoria> x = BD.TraerCategorias();
            ViewBag.Categorias = x;
            return View();
        }
        public ActionResult AccionCategoria(string Accion, int IdCategoria)
        {
            ViewBag.Accion = Accion;
            ViewBag.disabled = new { };
            if(Accion =="Eliminar"|| Accion =="Ver"||Accion =="Modificar")
            {
                Categoria x = BD.TraerCategoria(IdCategoria);
                if(Accion == "Eliminar"|| Accion =="Ver")
                {
                    ViewBag.disabled=new { disabled = "disabled" };
                }
                return View("AccionCategoria", x);
            }
            else if (Accion =="Insertar")
            {
                return View();
            }
            return View();
        }
        public ActionResult AccionCategoria(string Accion, int IdCategoria)
        {
            ViewBag.Accion = Accion;
            ViewBag.disabled = new { };
            if (Accion == "Eliminar" || Accion == "Ver" || Accion == "Modificar")
            {
                Categoria x = BD.TraerCategoria(IdCategoria);
                if (Accion == "Eliminar" || Accion == "Ver")
                {
                    ViewBag.disabled = new { disabled = "disabled" };
                }
                return View("AccionCategoria", x);
            }
            else if (Accion == "Insertar")
            {
                return View();
            }
            return View();
        }
    }
}