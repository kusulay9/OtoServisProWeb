using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServisPro.Controllers.Web
{
    public class KampanyaController : Controller
    {
        Repository<Kampanya> rpKampanya = new Repository<Kampanya>();
        // GET: Kampanya
        public ActionResult Index()
        {
            var kampanya = rpKampanya.List().FirstOrDefault();
            return View(kampanya);
        }
    }
}