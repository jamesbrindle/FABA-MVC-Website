using System.Web.Mvc;

namespace IR_BackOffice.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
