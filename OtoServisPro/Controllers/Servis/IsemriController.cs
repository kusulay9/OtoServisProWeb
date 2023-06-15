using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServisPro.Controllers.Servis
{
    public class IsemriController : Controller
    {
        private readonly Repository<Musteri> rpMusteri = new Repository<Musteri>();
        private readonly Repository<Marka> rpMarka = new Repository<Marka>();
        // GET: Isemri
        public ActionResult Index(string ara)
        {
            if (ara == "" || ara == null)
            {
                var musteri = rpMusteri.Get().OrderByDescending(x => x.MusteriId).Take(20).ToList();
                return View(musteri);
            }
            var musteriAra = rpMusteri.Get(x => x.AdSoyad.Contains(ara) || x.Telefon.Contains(ara)).ToList();
            return View(musteriAra);

        }

        public ActionResult IsemriOlustur(int musteriid)
        {
            ViewBag.Marka = rpMarka.List();
            return View();
        }
    }
}