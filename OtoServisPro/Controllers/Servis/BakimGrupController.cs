using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServisPro.Controllers.Servis
{
    public class BakimGrupController : Controller
    {
        private readonly Repository<BakimGrup> rpBakimGrup = new Repository<BakimGrup>();
        private readonly Repository<Bakim> rpBakim = new Repository<Bakim>();
        // GET: BakimGrup
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult BakimDoldur(int bakimgrupid)
        {
            var bakimGrup = rpBakim.Get(x => x.BakimGrupId == bakimgrupid).Select(x => new { x.BakimId, x.BakimAdi }).ToList();
            return Json(bakimGrup, JsonRequestBehavior.AllowGet);
        }
    }
}