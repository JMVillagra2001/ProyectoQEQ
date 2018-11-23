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
        public ActionResult Iniciarsesionexitoso(Usuarios x)
        {
            if (ModelState.IsValid)
            {
                bool a = BD.OtroLogin(x);
                if (a)
                {
                    return View("Juego");
                }
                return View("Iniciarsesion");
            }
            else
            {
                return View("Juego");
            }
        }
        public ActionResult Juego()
        {
            List<Categoria> x = BD.TraerCategorias();
            ViewBag.Categorias = x;
            return View();
        }
        public ActionResult Mostrar_personajes(Personajes x, int tCate, int idPersonajes)
        {
            if (tCate == -1)
            {
                ViewBag.Categorias = BD.TraerCategorias();
                ViewBag.Error = "Seleccione una categoría";
                return View("Index");
            }
            if (tCate != 0)
            {
                Personajes MiPersonaje = new Personajes();
                List<Personajes> MisPersonajes = new List<Personajes>();
               // MisPersonajes = BD.PreguntasxPersonaje(idPersonajes);
                int Num = MisPersonajes.Count();
                int n = new Random().Next(1, Num);
                MiPersonaje = MisPersonajes[n - 1];
                Session["PersonajeAzar"] = MiPersonaje;
            }
            else
            {
                Personajes MiPersonaje2 = new Personajes();
                List<Personajes> MisPersonajes1 = new List<Personajes>();
                MisPersonajes1 = BD.TraerPersonaje(x);
                int Num = MisPersonajes1.Count();
                int n = new Random().Next(1, Num);
                MiPersonaje2 = MisPersonajes1[n];
                Session["PersonajeAzar"] = MiPersonaje2;
            }
            if (tCate != 0)
            {
                List<Personajes> ListaPersonajes = new List<Personajes>();
               // ListaPersonajes = BD.PreguntasxPersonaje(idPersonajes);
                ViewBag.Lista = ListaPersonajes;
            }
            else
            {
                List<Personajes> ListaPersonajes = new List<Personajes>();
                
                ListaPersonajes = BD.TraerPersonaje(x);
                ViewBag.Lista = ListaPersonajes;
            }
            return View();
        }
    }
}