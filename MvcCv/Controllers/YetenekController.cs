using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        GenericRepository<yeteneklerim> repo = new GenericRepository<yeteneklerim>();

        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(yeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.id == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.id == id);
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekDuzenle(yeteneklerim p)
        {
            var y = repo.Find(x => x.id == p.id);
            y.yetenek = p.yetenek;
            y.oran = p.oran;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}