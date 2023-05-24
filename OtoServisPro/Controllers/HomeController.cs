using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Web;
using System.Linq;
using System.Web.Mvc;

namespace OtoServis.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository<Slider> rpSlider = new Repository<Slider>();
        private readonly Repository<Kampanya> rpKampanya = new Repository<Kampanya>();
        private readonly Repository<Uygulama> rpUygulama = new Repository<Uygulama>();
        private readonly Repository<Hakkimizda> rpHakkimizda = new Repository<Hakkimizda>();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Slider = rpSlider.List();
            ViewBag.Kampanya = rpKampanya.List().FirstOrDefault();
            ViewBag.Uygulama = rpUygulama.List();
            ViewBag.Hakkimizda = rpHakkimizda.List().FirstOrDefault();

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
