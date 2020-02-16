using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using DelishDB;

namespace DelishWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var myTest = new List<string>();

            using (var db = new DelishCFdbEF())
            {

                var query = from d in db.dishes

                            select d.name;

                foreach (var item in query)
                {
                    myTest.Add(item);
                }

            }

            return View(myTest);



        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Menu()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}