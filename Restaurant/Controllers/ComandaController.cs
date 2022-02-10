using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class ComandaController : Controller
    {
        private MeniuDbContext mdbctx = new MeniuDbContext();
        // GET: Comanda
        public ActionResult Index()
        {
            return View(mdbctx.Meniuri.ToList());
        }
    }
}