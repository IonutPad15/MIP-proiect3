using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using Restaurant.Helpers;
using System.Data.Entity;
namespace Restaurant.Controllers
{
    public class ProdusController : Controller
    {
        private ProdusDbContext dbCtx = new ProdusDbContext();
        // GET: Produs
        public ActionResult Index()
        {
            return View(dbCtx.Produse.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProdusModel msg)
        {
            if (ModelState.IsValid)
            {
                dbCtx.Produse.Add(msg);
                dbCtx.SaveChanges();

                return RedirectToAction("Index");
            }
            Task.Run(() => TraceWriter.WriteLineToTraceAsync("Model state was not valid in \"Create\" post method in \"Produs Controller\"."));
            return View(msg);
        }
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                Task.Run(() => TraceWriter.WriteLineToTraceAsync("Id had no value in \"Edit\" get method in \"Produs Controller\"."));
                return HttpNotFound();
            }
            ProdusModel produs = dbCtx.Produse.Find(id);
            if (null == produs)
            {
                Task.Run(() => TraceWriter.WriteLineToTraceAsync("\"meniu\" was null in \"Edit\" get method in \"Produs Controller\"."));
                return HttpNotFound();
            }
            return View(produs);
        }
        [HttpPost]
        public ActionResult Edit(ProdusModel produs)
        {
            if (ModelState.IsValid)
            {
               
                dbCtx.Entry(produs).State = System.Data.Entity.EntityState.Modified;
                dbCtx.SaveChanges();
                return RedirectToAction("Index");

            }
            Task.Run(() => TraceWriter.WriteLineToTraceAsync("Model state was not valid in \"Edit\" post method in \"Produs Controller\"."));
            return View(produs);
        }

   

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return HttpNotFound();
                }
                ProdusModel produs = dbCtx.Produse.Find(id);
                if (produs == null)
                {
                    return HttpNotFound();
                }
                return View(produs);
            }
            catch (Exception ex)
            {
                Task.Run(() => Helpers.TraceWriter.WriteLineToTraceAsync(ex.Message));
                return View();
            }
        }

  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ProdusModel produs = dbCtx.Produse.Find(id);
                dbCtx.Produse.Remove(produs);
                dbCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Task.Run(() => Helpers.TraceWriter.WriteLineToTraceAsync(ex.Message));
                return HttpNotFound();
            }
        }
    } 
}

