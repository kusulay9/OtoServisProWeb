using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Web;
using System.Web.Mvc;

namespace OtoServis.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository<Slider> rpSlider = new Repository<Slider>();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Slider = rpSlider.List();
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AdminDash()
        {

            return View();
        }

    }
}
