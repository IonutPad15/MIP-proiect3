using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;
using System.Text;
using System.Threading.Tasks;
//using Restaurant.Helpers;

namespace Restaurant.Controllers
{
    public class CreeareComandaController : Controller
    {
        public static double sumatotal =0;
        public static StringBuilder sb;
        // GET: CreeareComanda
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult CalculateTotal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CalculateTotalResult()
        {
            try
            {
                MeniuDbContext mdctx = new MeniuDbContext();
                StringBuilder sbChitanta = new StringBuilder();
                string idmeniuri = Request["txtMeniu"].ToString();
                string amount = Request["txtAmount"].ToString();
                StringBuilder sbNeformatat = new StringBuilder();
                while (amount[amount.Length - 1] == ' ')
                {
                    amount = amount.Remove(amount.Length - 1);
                }
                while (idmeniuri[idmeniuri.Length - 1] == ' ')
                {
                    idmeniuri = idmeniuri.Remove(idmeniuri.Length - 1);
                }
                var meniuri = mdctx.Meniuri.ToList();
                List<int> idlist = new List<int>();
                int nrid = 0;
                foreach (string id in idmeniuri.Split(' '))
                {
                    idlist.Add(Convert.ToInt32(id));
                    ++nrid;
                }
                List<int> amountlist = new List<int>();
                int nramount = 0;
                foreach (string amnt in amount.Split(' '))
                {
                    amountlist.Add(Convert.ToInt32(amnt));
                    ++nramount;
                }
                if (nramount == nrid)
                {
                    int[] amountv = new int[nramount];
                    int i = 0;
                    foreach (var iamn in amountlist)
                    {
                        amountv[i] = iamn;
                        ++i;
                    }
                    double suma = 0;
                    i = 0;
                    foreach (int id in idlist)
                    {
                        var meniu = mdctx.Meniuri.SingleOrDefault(m => m.Id == id);
                        if (meniu != null)
                        {
                            if (amountv[i] != 0)
                            {
                                sbChitanta.Append(amountv[i] + "x");
                                sbChitanta.Append(meniu.Nume + "         ");
                                sbChitanta.Append(meniu.Pret + " lei <br/>");
                                sbNeformatat.Append(amountv[i] + "x");
                                sbNeformatat.Append(meniu.Nume + "         ");
                                sbNeformatat.Append(meniu.Pret + " lei\n");
                                suma += amountv[i] * meniu.Pret;
                                sb = sbChitanta;
                            }
                        }
                        ++i;
                    }
                    sumatotal = suma;
                    if (suma != 0)
                    {
                        sbChitanta.Append("<b>Total :</b> " + suma + " lei<br/>");
                        sbNeformatat.Append("Total : " + suma + " lei\n");
                        sbNeformatat.Replace('.',',');
                        CumparareModel.Total = sbNeformatat.ToString();
                        return RedirectToAction("Index", "Cumparare");
                    }
                    else
                    {
                        sbChitanta.Append("Nu ati comandat nimic");
                        return Content(sbChitanta.ToString());
                    }
                }
                else
                {
                    sbChitanta.Append("Lista de id-uri si lista de numar de meniuri nu corespund");
                    return Content(sbChitanta.ToString());
                }
            }
            catch(Exception ex)
            {
                Task.Run(() => Helpers.TraceWriter.WriteLineToTraceAsync(ex.Message));
                return RedirectToAction("Index");
            }

        }
    }
}
