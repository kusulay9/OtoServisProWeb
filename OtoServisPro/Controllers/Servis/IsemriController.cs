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
        private readonly Repository<Islem> rpIslem = new Repository<Islem>();
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
            var baslik = rpIsemri.Get(x => x.IsemriId == isemriid,includeProperties:"Musteri").FirstOrDefault();
            ViewBag.Title="İşlem Yap - Plaka: " + baslik.Plaka + " - Müşteri : " +  baslik.Musteri.AdSoyad;
            ViewBag.BakimGrup = rpBakimGrup.List();
            ViewBag.IsemriId = isemriid;
            return View(rpIslem.Get(x=> x.IsemriId==isemriid).OrderByDescending(x=> x.IslemId).ToList());
        }
    
        public ActionResult IslemKaydet(Islem islem)
        {
            rpIslem.Insert(islem);
            return RedirectToAction("IslemYap", new {isemriid=islem.IsemriId });
        }
        public ActionResult IslemSil (int id)
        {
            var silinecek = rpIslem.GetById(id);
            rpIslem.Delete(silinecek);
            return RedirectToAction("IslemYap", new { isemriid = silinecek.IsemriId });        
        }
        public ActionResult KaydetveKapat(int IsemriId, string OdemeSekli, string Aciklama, decimal AlinanUcret)
        {
            var isemri = rpIsemri.GetById(IsemriId);
            if (isemri.Kapali)
            {
                TempData["No"] = "Bu iş emri zaten kapalıdır";
                return RedirectToAction("AcikIsemirleri");
            }
            isemri.OdemeSekli = OdemeSekli;
            isemri.Aciklama = Aciklama;
            isemri.AlinanUcret = AlinanUcret;
            isemri.Kapali = true;
            isemri.KapatmaTarihi = DateTime.Now;
            rpIsemri.Update(isemri);
            TempData["Ok"] = "İş Emri Kaydedildi ve Kapatıldı";
            return RedirectToAction("RaporSayfasi",new {isemriid= IsemriId });
        }
        public ActionResult RaporSayfasi(int isemriid )
        {
            ViewBag.IsemriId = isemriid;
            return View();
        }
        public ActionResult HizliIsemriOlustur (int isemriId)
        {
            return View(rpIsemri.GetById(isemriId));
        }
        [HttpPost]
        public ActionResult HizliIsemri(Isemri isemri)
        {
            var mevcut = rpIsemri.GetById(isemri.IsemriId);
            if (rpIsemri.Get(x=> x.Plaka==mevcut.Plaka && x.MusteriId==mevcut.MusteriId && x.Kapali==false).Count()>0)
            {
                TempData["No"] = "Bu plaka için iş emri zaten açık";
                return RedirectToAction("AcikIsemirleri");
            }
            isemri.SaseNo = mevcut.SaseNo;
            isemri.Plaka = mevcut.Plaka.Trim();
            isemri.YakitTuru = mevcut.YakitTuru;
            isemri.Kapali = false;
            isemri.Aciklama = null;
            isemri.AlinanUcret = 0;
            isemri.OdemeSekli = null;
            isemri.KapatmaTarihi = null;
            isemri.ModelId = mevcut.ModelId;
            isemri.MusteriId = mevcut.MusteriId;
            isemri.ModelYil = mevcut.ModelYil;
            rpIsemri.Insert(isemri);
            return RedirectToAction("AcikIsemirleri");
        }
    }
}