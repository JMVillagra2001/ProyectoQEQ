using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ2.Models;

namespace QEQ2.Controllers
{
    public class BackOfficeController : Controller
    {
        public int ValidarDato()
        {
            int val = 0;
            if ((Usuarios)Session["Usuario"] == null)
            {
                val = 1;
            }
            if ((Usuarios)Session["Usuario"] != null && (bool)Session["Admin"] != true)
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
            if (ModelState.IsValid)
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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginExitoso(Usuarios x)
        {
            if (!ModelState.IsValid)
            {
                bool a = BD.Login(x);
                if (a)
                {
                    Session["Usuario"] = x.Nombre;
                    return View("HomeBackOffice");
                }
                else
                {
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }

        /*
           bool a = BD.Login(x);
            if (a)
            {
                Session["Usuario"] = x.Nombre;
                return View("HomeBackOffice");
            }
            else
            {
                return View("Login");
            }
            */


        public ActionResult HomeBackOffice(Usuarios x)
        {

            if (Session["Usuario"] != null)
            {
                Session["Usuario"] = x.Nombre;
                return View("HomeBackOffice");
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult LogOut()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Categoria(Usuarios c)
        {

            if (Session["Usuario"] != null)
            {
                Session["Usuario"] = c.Nombre;
                List<Categoria> x = BD.TraerCategorias();
                ViewBag.Categorias = x;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult AccionCategoria(string Accion, int IdCategoria)
        {
            ViewBag.Accion = Accion;
            ViewBag.ID = IdCategoria;
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
        public ActionResult GrabarCategoria(Categoria P, int IdCategoria, string Accion)
        {
            ViewBag.Accion = Accion;
            ViewBag.disabled = new { };
            switch (Accion)
            {
                case "Insertar":
                    if (!ModelState.IsValid)
                    {
                        return View("AccionCategoria", P);
                    }
                    else
                    {
                        BD.CrearCategoria(P);
                        return RedirectToAction("HomeBackOffice", "BackOffice");
                    }
                    break;
                case "Modificar":
                    if (!ModelState.IsValid)
                    {
                        return View("AccionCategoria", P);

                    }
                    else
                    {
                        BD.ModificarCategoria(P);
                        return RedirectToAction("HomeBackOffice", "BackOffice");
                    }
                    break;
                case "Eliminar":
                    BD.EliminarCategorias(P);
                    return RedirectToAction("HomeBackOffice", "BackOffice");
                    break;
                default:
                    break;
            }
            return View();
        }
        public ActionResult Preguntas(Preguntas P)
        {
            if (!ModelState.IsValid)
            {
                if (Session["Usuario"] != null)
                {
                    List<Preguntas> x = BD.TraerPreguntas(P);
                    ViewBag.Preguntas = x;
                    ViewBag.ListaCategorias = BD.TraerCategorias();
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("HomeBackOffice");
            }
        }
        public ActionResult AccionPreguntas(string Texto, int IdPreguntas, string Accion)
        {
            ViewBag.Accion = Accion;
            BD MICONEXION = new BD();
            ViewBag.ListaCategorias = BD.TraerCategorias();
            ViewBag.ID = IdPreguntas;
            ViewBag.Texto = Texto;
            ViewBag.disabled = new { };
            if (Accion == "Eliminar" || Accion == "Ver" || Accion == "Modificar")
            {
                Preguntas x = BD.TraerPregunta(IdPreguntas);
                if (Accion == "Ver")
                {

                    ViewBag.disabled = new { disabled = "disabled" };
                }
                return View("AccionPreguntas", x);
            }
            else if (Accion == "Insertar")
            {
                return View();
            }
            return View();

        }
        public ActionResult GrabarPregunta(Preguntas P, int IdPreguntas, string Accion, string Texto, int tCate)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Accion = Accion;
                ViewBag.disabled = new { };
                switch (Accion)
                {
                    case "Insertar":
                        if (!ModelState.IsValid)
                        {
                            return View("AccionPreguntas", IdPreguntas);
                        }
                        else
                        {
                            BD.CrearPregunta(tCate, Texto);
                            return RedirectToAction("HomeBackOffice", "BackOffice");
                        }
                        break;
                    case "Modificar":
                        if (!ModelState.IsValid)
                        {
                            return View("AccionPreguntas", P);

                        }
                        else
                        {
                            BD.ModificarPreguntas(IdPreguntas, Texto);
                            return RedirectToAction("HomeBackOffice", "BackOffice");
                        }
                        break;
                    case "Eliminar":
                        BD.EliminarPreguntas(IdPreguntas);
                        return RedirectToAction("HomeBackOffice", "BackOffice");
                        break;
                    default:
                        break;
                }
                return View();
            }
            else
            {
                return View("HomeBackOffice");
            }
        }
        public ActionResult Personaje(Personajes P)
        {
            List<Personajes> x = BD.TraerPersonaje(P);
            ViewBag.Personaje = x;
            ViewBag.ListaCategorias = BD.TraerCategorias();
            return View();
        }
        public ActionResult AccionPersonaje(Preguntas P, string Imagen, string Nombre, int IdPersonaje, string Accion)
        {
            ViewBag.Accion = Accion;
            BD MICONEXION = new BD();
            ViewBag.ListaCategorias = BD.TraerCategorias();
            ViewBag.ID = IdPersonaje;
            ViewBag.Nombre = Nombre;
            ViewBag.disabled = new { };
            if (Accion == "Eliminar" || Accion == "Ver" || Accion == "Modificar")
            {
                Personajes x = BD.TraerPersonajes(IdPersonaje);
                if (Accion == "Ver")
                {
                    ViewBag.disabled = new { disabled = "disabled" };
                }
                return View("AccionPersonaje", x);
            }
            else if (Accion == "Insertar")
            {
                return View();
            }
            if (Accion == "Preguntas")
            {
                ViewBag.IdPersonaje = IdPersonaje;
                List<Preguntas> x = BD.TraerPreguntas(P);
                ViewBag.Preguntas = x;
               
                return View("ListaPreguntasPersonaje");
            }
            return View();

        }
        public ActionResult AccionPersonajePreguntas(Preguntas P, int IdPersonaje)
        {
            List<Preguntas> x = BD.TraerPreguntas(P);
            ViewBag.Preguntas = x;
            List<PreguntasXpersonaje> c = BD.PreguntasxPersonaje(IdPersonaje);
            ViewBag.IdPersonaje = c;
            return View();
        }
        public ActionResult GrabarPreguntasPersonaje(int IdPersonaje, int[]tCate)
        {
            BD.InsertarPreguntasXpersonajes(tCate, IdPersonaje);
            return View("HomeBackOffice");
        }
        public ActionResult GrabarPersonaje(Personajes P, int IdPersonaje, string Accion, string Nombre, int tCate, string Imagen)
        {
            P.Categoria = tCate;
            ViewBag.Accion = Accion;
            ViewBag.disabled = new { };
            switch (Accion)
            {
                case "Insertar":
                    if (!ModelState.IsValid)
                    {
                        return View("HomeBackOffice");
                    }
                    else
                    {
                        BD.InsertarPersonajes(P);
                        return View("HomeBackOffice");
                    }
                    break;
                case "Preguntas":
                    
                        break;
                case "Modificar":

                    BD.ModificarPersonajes(P);
                    return View("HomeBackOffice");
                    break;
                case "Eliminar":
                    BD.EliminarPersonajes(IdPersonaje);
                    return RedirectToAction("HomeBackOffice", "BackOffice");
                    break;
                default:
                    break;
            }
            return View();

        }
    }
}