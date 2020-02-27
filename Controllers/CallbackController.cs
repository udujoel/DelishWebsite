using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace DelishWebsite.Controllers
{
    public class CallbackController : Controller
    {
        // GET: Callback
        public async Task<ActionResult> Index()
        {
            string secretKey              = ConfigurationManager.AppSettings["PaystackSecret"];
            var    paystackTransactionAPI = new PaystackTransaction(secretKey);
            var    tranxRef               = HttpContext.Request.QueryString["reference"];



            if (tranxRef != null)
            {
                var response = await paystackTransactionAPI.VerifyTransaction(tranxRef);
                if (response.status)
                {

//                    try
//                    {
//                        using (var db = new DelishDB())
//                        {
//
//                            int currentCount = 0;
//                            currentCount = (int) Session["count"];
//
//                            db.loandetails.Find((int) Session["selectedItemId"]).count = currentCount + 1;
//                            db.loandetails.Find((int) Session["selectedItemId"]).date  = DateTime.Now;
//                            //  Update subscription table
//
//                            var user = new subscription
//                            {
//                                userid    = User.Identity.GetUserName().ToLower(),
//                                startdate = DateTime.Now,
//                                enddate   = DateTime.Now.AddMonths(1)
//                            };
//
//
//                            db.subscriptions.Add(user);
//
//
//
//                            db.SaveChanges();
//
//
//                        }
//                    }
//                    catch (Exception e)
//                    {
//
//                        return View("Error");
//                    }

                    return View(response);
                }
            }

            return View("paymenterror");
        }

        public ActionResult Callback()
        {


            return View("success");
        }
    }
}