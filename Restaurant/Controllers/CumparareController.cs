using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Controllers;
using Restaurant.Models;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class CumparareController : Controller
    {
        // GET: Cumparare
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Total()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TotalResult()
        {
            try
            {
                double suma = CreeareComandaController.sumatotal;
                double plata = Convert.ToDouble(Request["txtSuma"].ToString());
                StringBuilder sb = new StringBuilder();
                sb = CreeareComandaController.sb;
                if (plata - suma >= 0)
                {
                    sb.Append("Suma :   " + plata + " lei <br/>");
                    sb.Append("Rest:    " + (plata - suma) + " lei <br/>");
                }
                else
                {
                    sb.Append("Fonduri insuficiente!");
                }
                return Content(sb.ToString());
            }
            catch(Exception ex)
            {
                Task.Run(() => Helpers.TraceWriter.WriteLineToTraceAsync(ex.Message));
                return RedirectToAction("Index");
            }
        }
    }
}
