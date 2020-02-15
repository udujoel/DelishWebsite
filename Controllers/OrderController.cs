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
    }
}