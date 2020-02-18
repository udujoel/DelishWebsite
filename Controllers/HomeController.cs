using System;
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

            var home_text = new List<home_text>();
            var home_about = new List<home_about>();
            var home_special = new List<home_special>();

            using (var db = new DelishCFdbEF())
            {
                try
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
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
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
           
            var menuList = new List<dish>();

            using (var db = new DelishCFdbEF())
            {
                try
                {
                    var query = from d in db.dishes
                                orderby d.id
                                select d;

                    foreach (var dish in query)
                    {
                        menuList.Add(dish);
                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            ViewBag.Menu = menuList;



            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult Subscribe(subscriber email)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            try
            {
                using (var db = new DelishCFdbEF())
                {
                    var subscriber = new subscriber { subscriber_email = email.subscriber_email };
                    db.subscribers.Add(subscriber);
                    db.SaveChanges();


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }






            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public ActionResult Enquiry(enquiry _enquiry)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            try
            {
                using (var db = new DelishCFdbEF())
                {
                    var newEnquiry = new enquiry() { name = _enquiry.name, phone = _enquiry.phone, email = _enquiry.email, detail = _enquiry.detail };
                    db.enquiries.Add(newEnquiry);
                    db.SaveChanges();


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }






            return RedirectToAction("Index");
        }
    }
}