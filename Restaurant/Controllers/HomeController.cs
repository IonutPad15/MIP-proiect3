using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "The Forest Man este un nou restaurant " +
                "aici pentru a va aduce zambete, dar si pentru a va satisface fanteziile culinare.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pagina de contact";

            return View();
        }
        public ActionResult ChangeLanguage(string lang)
        {
            Session["lang"] = lang;
            return RedirectToAction("Index", "Home", new { language = lang });
        }
    }
}