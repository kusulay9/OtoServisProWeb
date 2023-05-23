using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Web;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace OtoServisPro.Controllers.Web
{
    public class SliderController : Controller
    {
        // GET: Slider
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost] // HTTP Post isteğiyle çalışan bir aksiyon
        public ActionResult SliderKaydet(Slider slider, HttpPostedFileBase resimyol)
        {
            if (resimyol != null && resimyol.ContentLength > 0)
            {
                string uzanti = Path.GetExtension(resimyol.FileName);
                string dosyaAdi = Guid.NewGuid().ToString();
                string tamAd = dosyaAdi + uzanti;
                string yol = Path.Combine(Server.MapPath("~/Images/Slider/"), tamAd);
                resimyol.SaveAs(yol);
                string kaydedilecekYol = "/Images/Slider/" + tamAd;
                slider.ResimYol = kaydedilecekYol;

                Repository<Slider> rpSlider = new Repository<Slider>();
                rpSlider.Insert(slider);
            }

            return RedirectToAction("Index");
        }
    }
}
