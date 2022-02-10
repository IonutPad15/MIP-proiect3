using System.Web;
using System.Web.Optimization;
using Restaurant.Models;
using System.Linq;
using Restaurant.Controllers;
using System.Data;
using System.Threading.Tasks;
using Restaurant.Helpers;

namespace Restaurant
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            XMLHandling.incarcareXML();
            UserDbContext udb = new UserDbContext();
            if (udb.Users.Count() == 0)
            {
                CryptoHashHelper crypto = new CryptoHashHelper();
                UserModel user = new UserModel()
                {
                    Username = "Admin",
                    Password = crypto.GetHash("1234"),
                    Nrtel = "0761387906"
                };
                udb.Users.Add(user);
                udb.SaveChanges();
            }
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
