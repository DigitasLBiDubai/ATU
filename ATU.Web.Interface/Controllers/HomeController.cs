using System.Web.Mvc;

namespace ATU.Web.Interface.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Question");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}