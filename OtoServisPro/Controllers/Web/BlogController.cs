using OtoServisPro.BusinessLayer.Abstract;
using OtoServisPro.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServisPro.Controllers.Web
{
    public class BlogController : Controller
    {
        private readonly Repository<Blog> rpBlog = new Repository<Blog>();
        // GET: Blog
        public ActionResult Index()
        {
            return View(rpBlog.List().OrderByDescending(x => x.BlogId));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            try
            {
                blog.Tarih = DateTime.Now;
                rpBlog.Insert(blog);
                TempData["Ok"] = "Blog kaydedildi";
            }
            catch (Exception)
            {

                TempData["No"] = "Hata Oluştu";
            }

            return RedirectToAction("Index");
        }
    }
}