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
    [Authorize(Roles = "Admin")]

    public class HakkimizdaController : Controller
    {
        private readonly Repository<Hakkimizda> rpHakkimizda = new Repository<Hakkimizda>();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            if (rpHakkimizda.List().Count == 0)
            {
                Hakkimizda h = new Hakkimizda();
                h.Icerik = "-";
                rpHakkimizda.Insert(h);
            }
            return View(rpHakkimizda.List().FirstOrDefault());
        }
        [HttpPost]
        public ActionResult HakkimizdaKaydet(Hakkimizda hakkimizda, HttpPostedFileBase Resim)
        {
            if (rpHakkimizda.List().Count > 0)
            {
                string uzanti = Path.GetExtension(Resim.FileName);
                string dosyaadi = Path.GetFileNameWithoutExtension(Resim.FileName) + "_" + Guid.NewGuid() + uzanti;
                string resimYol = Server.MapPath("/Images/Hakkimizda/" + dosyaadi);
                Resim.SaveAs(resimYol);
                WebImage image = new WebImage(resimYol);
                image.Resize(500, 500, true, true);
                image.Save(resimYol);
                var guncellenecek = rpHakkimizda.List().FirstOrDefault();
                guncellenecek.Icerik = hakkimizda.Icerik;
                guncellenecek.Resim = "/Images/Hakkimizda/" + dosyaadi;
                rpHakkimizda.Update(guncellenecek);

            }
            return RedirectToAction("Index");
        }
    }
}