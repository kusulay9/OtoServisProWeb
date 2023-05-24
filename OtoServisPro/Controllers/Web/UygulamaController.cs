using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OtoServisPro.Controllers.Web
{
    public class UygulamaController : Controller
    {
        private readonly Repository<Uygulama> rpUygulama = new Repository<Uygulama>();
        // GET: Uygulama
        public ActionResult Index()
        {

            return View(rpUygulama.List().OrderByDescending(x=> x.UygulamaId));
        }
        [HttpPost]
        public ActionResult UygulamaKaydet(Uygulama uygulama,HttpPostedFileBase Resim)
        {
            if (Resim != null)
            {
                string uzanti = Path.GetExtension(Resim.FileName);
                string dosyaadi = Path.GetFileNameWithoutExtension(Resim.FileName) + "_" + Guid.NewGuid() + uzanti;
                string resimDetay = Server.MapPath("/Images/Uygulamalar/" + dosyaadi);
                Resim.SaveAs(resimDetay);
                WebImage image = new WebImage(resimDetay);
                image.Resize(285, 180, true, true);
                image.Save(resimDetay);
                uygulama.Resim = "/Images/Uygulamalar/" + dosyaadi;
                rpUygulama.Insert(uygulama);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UygulamaSil(int id)
        {
            try
            {
                var uygulama = rpUygulama.GetById(id);
                string resimYolu = Request.MapPath(uygulama.Resim);
                rpUygulama.Delete(uygulama);
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