using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServisPro.Controllers.Servis
{
    public class ModelMarkaController : Controller
    {
        private readonly Repository<Model> rpModeller = new Repository<Model>();
        // GET: MarkaModel
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ModelDoldur(int markaid)
        {
            var modeller = rpModeller.Get(x => x.MarkaId == markaid).Select(x => new { x.ModelId, x.ModelAd }).ToList();
            return Json(modeller, JsonRequestBehavior.AllowGet);
        }
    }
}