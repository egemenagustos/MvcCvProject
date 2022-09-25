using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<admin> repo = new GenericRepository<admin>();

        public ActionResult Index()
        {
            var admin = repo.List();
            return View(admin);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(admin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            admin t = repo.Find(x => x.id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            admin t = repo.Find(x => x.id == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult Duzenle(admin p)
        {
            admin t = repo.Find(x => x.id == p.id);
            t.kullaniciAdi = p.kullaniciAdi;
            t.sifre = p.sifre;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}