using System.Linq;
using System.Web.Mvc;

using DelishDB;

namespace DelishWebsite.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET

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
            bool isInCart = false;
            var cartItem = new cart();



            using (var db = new DelishCFdbEF())
            {
                var query1 = from d in db.dishes
                             where d.id == dishid
                             select d.price;

                purchase_price = query1.FirstOrDefault();

                //check if product exist in cart

                var checkCartQuery = from d in db.carts
                                     where d.product_id == dishid
                                     select d.quantity;

                isInCart = (checkCartQuery == null) ? false : true;

                if (isInCart)
                {
                    quantity = checkCartQuery.First();

                    cartItem.product_id = dishid;
                    cartItem.quantity = quantity + 1;
                    cartItem.purchase_price = purchase_price;
                    cartItem.total = (int)(purchase_price * quantity);
                }
                else
                {
                    cartItem.product_id = dishid;
                    cartItem.quantity = 1;
                    cartItem.purchase_price = purchase_price;
                    cartItem.total = (int)(purchase_price * quantity);
                }


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