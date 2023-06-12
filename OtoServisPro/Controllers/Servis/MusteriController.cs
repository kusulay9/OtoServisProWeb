using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServisPro.Controllers.Servis
{
    public class MusteriController : Controller
    {
        private readonly Repository<Musteri> rpMusteri = new Repository<Musteri>();
        public ActionResult Index()
        {
            return View(rpMusteri.Get().OrderByDescending(x => x.MusteriId).Take(20).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Musteri musteri)
        {
            rpMusteri.Insert(musteri);
            TempData["Ok"]="Müşteri Kaydedildi";
            return RedirectToAction("Index");
        }

    }
}