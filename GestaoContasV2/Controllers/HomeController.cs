using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestaoContasV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult PainelUsuario()
        {
            return View();
        }

        public ActionResult CadastroUsuario()
        {
            return View();
        }

        public ActionResult CadastroConta()
        {
            return View();
        }

        public ActionResult CadastroFatura()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CadastroLogin()
        {
            return View();
        }
    }
}
