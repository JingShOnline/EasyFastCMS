using System.Web.Mvc;

namespace EasyFast.Web.Controllers
{
    public class AboutController : EasyFastControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}