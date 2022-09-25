using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        GenericRepository<hobilerim> repo = new GenericRepository<hobilerim>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }

        [HttpPost]
        public ActionResult Index(hobilerim p)
        {
            var t = repo.Find(x => x.id == 1);
            t.aciklama = p.aciklama;
            t.aciklama2 = p.aciklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}