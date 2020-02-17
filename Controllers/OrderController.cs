using System.Web.Mvc;

namespace DelishWebsite.Controllers
{
    public class OrderController : Controller
    {
        // GET
        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult AddToCart(int dishid)
        {


            return RedirectToRoute(new { Controller = "Home", action = "Menu" });
        }

        public void RemoveFromCart(int dishid)
        {



        }

        public ActionResult Checkout(int cartid)
        {


            return View();
        }
    }
}