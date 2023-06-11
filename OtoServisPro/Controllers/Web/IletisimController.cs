using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServisPro.Controllers.Web
{
    public class IletisimController : Controller
    {
        private readonly Repository<HaritaIletisim> rpIletisim = new Repository<HaritaIletisim>();
        // GET: İletisim
        public ActionResult Index()
        {
            if (rpIletisim.List().Count==0)
            {
                HaritaIletisim hi = new HaritaIletisim();
                hi.Harita = "-";
                hi.Iletisim = "-";
                rpIletisim.Insert(hi);

            }
            var iletisim = rpIletisim.List().FirstOrDefault();
            return View(iletisim);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Kaydet(HaritaIletisim iletisimx)
        {
            var guncellenecek = rpIletisim.GetById(iletisimx.HaritaIletisimId);
            guncellenecek.Harita = iletisimx.Harita;
            guncellenecek.Iletisim = iletisimx.Iletisim;
            rpIletisim.Update(guncellenecek);
            return RedirectToAction("Index");
        }
    }
}