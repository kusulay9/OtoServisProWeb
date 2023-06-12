﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServisPro.Controllers
{
    public class PanelController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Panel
        public ActionResult Index()
        {
            return View();
        }
    }
}