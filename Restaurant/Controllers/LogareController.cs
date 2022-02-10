using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;
using System.Threading.Tasks;
using Restaurant.Helpers;

namespace Restaurant.Controllers
{
    public class LogareController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logare()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogareResult()
        {
            string username = Request["txtUtilizator"].ToString();
            string password = Request["txtPassword"].ToString();

            using (UserDbContext udb = new UserDbContext())
            {
                var users = from utilizatori in udb.Users
                            where utilizatori.Username == username
                            select utilizatori;
                if (!users.Any())
                {
                    Task.Run(() => TraceWriter.WriteLineToTraceAsync("User introdus la logare negasit."));
                    return Content("User incorect!");
                }
                else
                {
                    UserModel user = new UserModel();
                    foreach (UserModel u in users)
                    {
                        user = u;
                    }
                    string hashedPassword = new CryptoHashHelper().GetHash(password);
                    hashedPassword = new CryptoHashHelper().GetHash(password);
                    hashedPassword = new CryptoHashHelper().GetHash(password);
                    if (user.Password != hashedPassword)
                    {
                        Task.Run(() => TraceWriter.WriteLineToTraceAsync("Utilizatorul a introdus o parola gresita."));
                        return Content("Parola incorecta.");
                    }
                    else
                    {
                        UserController.iduser = user.Id;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            /*
            if (password == "1234")
            {
                string mesaj = "Succes";
                UserController.iduser = 1;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string mesaj = "Eroare";
                return Content(mesaj);
            }*/
        }
        public ActionResult Delogare()
        {
            UserController.iduser = 0;
            return RedirectToAction("Index", "Home");
        }
    }
}