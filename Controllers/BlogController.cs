using System.Web.Mvc;

namespace DelishWebsite.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        //        public ActionResult Post(Post postid)
        //        {
        //            return View();
        //        }

        public ActionResult Post()
        {
            return View();
        }
    }
}