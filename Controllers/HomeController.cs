using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using DelishDB;

using DelishWebsite.Models;

namespace DelishWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var home_text = new List<home_text>();
            var home_about = new List<home_about>();
            var home_special = new List<home_special>();

            using (var db = new DelishCFdbEF())
            {

                var text_query = from d in db.home_text

                                 select d;
                var about_query = from d in db.home_about
                                  select d;
                var special_query = from d in db.home_special
                                    orderby d.id
                                    select d;


                foreach (var item in text_query)
                {
                    home_text.Add(item);
                }
                foreach (var item in about_query)
                {
                    home_about.Add(item);
                }
                foreach (var item in special_query)
                {
                    home_special.Add(item);
                }

            }

            ViewBag.Home_Text = home_text;
            ViewBag.Home_About = home_about;
            ViewBag.Home_Special = home_special;

            return View();



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

        public ActionResult Subscribe(Email email)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (var db = new DelishCFdbEF())
            {
                try
                {

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }

            return View();
        }
    }
}