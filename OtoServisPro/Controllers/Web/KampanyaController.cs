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

    public class KampanyaController : Controller
    {
        Repository<Kampanya> rpKampanya = new Repository<Kampanya>();
        // GET: Kampanya
        public ActionResult Index()
        {
            if (rpKampanya.List().Count==0)
            {
                Kampanya k = new Kampanya();
                k.Icerik = "-";
                rpKampanya.Insert(k);
            }
            var kampanya = rpKampanya.List().FirstOrDefault();
            return View(kampanya);
        }
        [HttpPost]
        public ActionResult KampanyaKaydet(Kampanya kampana)
        {
            if (rpKampanya.List().Count>0)
            {
                var guncellenecek = rpKampanya.List().FirstOrDefault();
                guncellenecek.Icerik = kampana.Icerik;
                rpKampanya.Update(guncellenecek);
            }

            return RedirectToAction("Index");
        }
    }
}