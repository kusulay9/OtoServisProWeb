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
        private readonly Repository<Isemri> rpIsemri = new Repository<Isemri>();
        private readonly Repository<BakimGrup> rpBakimGrup = new Repository<BakimGrup>();
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
            var musteri = rpMusteri.GetById(musteriid);
            ViewBag.MusteriId = musteriid;
            ViewBag.AcikIsemirleri = rpIsemri.Get(x => x.Kapali == false && x.MusteriId == musteriid).ToList();
            ViewBag.KapaliIsemirleri = rpIsemri.Get(x => x.Kapali == true && x.MusteriId == musteriid).ToList();

            ViewBag.Title = "İş Emri Oluştur - " + musteri.AdSoyad;
            return View(rpIsemri.Get(x=> x.Kapali==true && x.MusteriId==musteriid).OrderByDescending(x=> x.GelisTarihi).ToList());
        }

        public ActionResult IsemriKaydet(Isemri isemri)
        {
            rpIsemri.Insert(isemri);
            return RedirectToAction("AcikIsemirleri");
        }
        public ActionResult AcikIsemirleri()
        {
            return View(rpIsemri.Get(x=> x.Kapali==false).ToList());
        }
        public ActionResult KapaliIsemirleri()
        {
            return View(rpIsemri.Get(x => x.Kapali == true).ToList());
        }
        public ActionResult IslemYap ( int isemriid)
        {
            ViewBag.BakimGrup = rpBakimGrup.List();
            return View();
        }
    
    }
}