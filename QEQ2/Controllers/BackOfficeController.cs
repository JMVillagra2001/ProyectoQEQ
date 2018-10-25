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
                    return View("HomeBackOffice");
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
            return View();            
        }
    }
}