using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Web;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServisPro.Controllers.Web
{
    public class SliderController : Controller
    {
        private readonly Repository<Slider> rpSlider = new Repository<Slider>();

        public ActionResult Index()
        {
            var slider = rpSlider.List().OrderByDescending(XmlSiteMapProvider => XmlSiteMapProvider.SliderId);
            return View(slider);
        }

        [HttpPost] // HTTP Post isteğiyle çalışan bir aksiyon
        public ActionResult SliderKaydet(Slider slider, HttpPostedFileBase resimyol)
        {

            try
            {
                if (resimyol != null && resimyol.ContentLength > 0)
                {
                    string uzanti = Path.GetExtension(resimyol.FileName);
                    string dosyaAdi = Path.GetFileNameWithoutExtension(resimyol.FileName) + "_" + Guid.NewGuid();//.ToString()
                    string tamAd = dosyaAdi + uzanti;
                    string yol = Path.Combine(Server.MapPath("~/Images/Slider/"), tamAd);
                    resimyol.SaveAs(yol);
                    string kaydedilecekYol = "/Images/Slider/" + tamAd;
                    slider.ResimYol = kaydedilecekYol;

                    rpSlider.Insert(slider);
                    TempData["Ok"] = "Kayıt Başarılı";
                }
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                TempData["No"] = "Hata Oluştu";
                return RedirectToAction("Index");

            }
        }
        [HttpPost]
        public ActionResult SliderSil(int id)
        {
            try
            {
                var slider = rpSlider.GetById(id);
                string resimYolu = Request.MapPath(slider.ResimYol);
                rpSlider.Delete(slider);
                if (System.IO.File.Exists(resimYolu))
                {
                    System.IO.File.Delete(resimYolu);
                }
                TempData["Ok"] = "Silme Tamamlandı";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["No"] = "Hata !";
                return RedirectToAction("Index");
            }
           
        }
    }

}
