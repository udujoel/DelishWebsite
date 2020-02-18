﻿using System.Linq;
using System.Web.Mvc;

using DelishDB;

namespace DelishWebsite.Controllers
{
    public class OrderController : Controller
    {
        // GET
        [Authorize]
        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult AddToCart(int dishid)
        {
            //get dish id
            //get price
            //get qty or set to 1
            //commit to db

            double purchase_price = 0;
            int quantity = 1;



            using (var db = new DelishCFdbEF())
            {
                var query1 = from d in db.dishes
                             where d.id == dishid
                             select d.price;

                purchase_price = query1.FirstOrDefault();





                var cartItem = new cart() { product_id = dishid, quantity = quantity, purchase_price = purchase_price, total = (int)(purchase_price * quantity) };
                db.carts.Add(cartItem);
                db.SaveChanges();

            }


            return RedirectToRoute(new { Controller = "Home", action = "Menu" });
        }

        public ActionResult UpdateCart(int CartId)
        {


            return RedirectToAction("Cart");
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