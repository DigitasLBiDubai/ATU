using System.Web.Mvc;

namespace ATU.Web.Interface.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return User.Identity.IsAuthenticated ? RedirectToAction("Index", "Question") : RedirectToAction("Login", "Account");
        }
    }
}