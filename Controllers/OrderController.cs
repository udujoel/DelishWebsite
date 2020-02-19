using DelishDB;

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DelishWebsite.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET

        public ActionResult Cart()
        {
            //render the cart from db

            var dishDetails = new List<dish>();

            double? total = 0;

            List<cart> cartItems;
            using (var db = new DelishCFdbEF())
            {
                total = db.carts.Sum(p => p.purchase_price * p.quantity);
                cartItems = db.carts.OrderBy(x => x.id).ToList();
                var dishDetail_query = db.dishes.ToList();

                foreach (var dish in dishDetail_query)
                {
                    if (cartItems.Exists(x => x.product_id == dish.id))
                    {
                        dishDetails.Add(dish);
                    }

                }


            }

            ViewBag.Dishdetails = dishDetails;
            ViewBag.Total = total;

            return View(cartItems);
        }

        public ActionResult AddToCart(int dishid)
        {
            //get dish id
            //get price
            //get qty or set to 1
            //commit to db

            var userCart = new List<cart>();
            double purchase_price = 0;

            //check if item already in cart

            bool isInCart = false;
            int _quantity = 1;
            int cartid = 0;




            using (var db = new DelishCFdbEF())
            {

                var cart_query = from d in db.carts
                                 orderby d.id
                                 select d;


                purchase_price = db.dishes.Find(dishid).price;



                //populate the usercart
                foreach (var item in cart_query)
                {
                    userCart.Add(new cart
                    {
                        id = item.id,
                        product_id = item.product_id,
                        quantity = item.quantity,
                        purchase_price = item.purchase_price,
                        total = item.total
                    });

                }

                //check usercart for dish
                foreach (var item in userCart)
                {
                    if (item.product_id == dishid)
                    {
                        isInCart = true;
                        _quantity = item.quantity;
                        cartid = item.id;
                    }
                }

                //increment count if in cart already

                if (isInCart)
                {
                    db.carts.Find(cartid).quantity++;

                }
                else
                {

                    db.carts.Add(new cart
                    {
                        product_id = dishid,
                        purchase_price = purchase_price,
                        quantity = _quantity,
                        total = (int)(_quantity * purchase_price)
                    });


                }



                db.SaveChanges();

            }



            return RedirectToRoute(new { Controller = "Home", action = "Menu" });
        }




        public ActionResult UpdateCart(int CartId, int quantity)
        {

            using (var db = new DelishCFdbEF())
            {
                db.carts.Find(CartId).quantity = quantity;
                db.SaveChanges();
            }

            return RedirectToAction("Cart");
        }

        public void RemoveFromCart(int Cartid, int quantity)
        {

            using (var db = new DelishCFdbEF())
            {
                db.carts.Find(Cartid).quantity = 0;
                db.SaveChanges();
            }

        }

        public ActionResult Checkout(int cartid)
        {

            //payment
            return View();
        }
    }
}