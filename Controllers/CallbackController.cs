using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Paystack.Net.SDK.Transactions;

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