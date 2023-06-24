using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServisPro.Controllers.Web
{
    [Authorize(Roles = "Admin")]

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
                hi.Unvan = "-";
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
            guncellenecek.Unvan = iletisimx.Unvan;
            rpIletisim.Update(guncellenecek);
            return RedirectToAction("Index");
        }
    }
}