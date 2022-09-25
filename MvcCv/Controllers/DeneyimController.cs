using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        DeneyimRepository repo = new DeneyimRepository();

        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(deneyimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            deneyimlerim t = repo.Find(x => x.id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            deneyimlerim t = repo.Find(x => x.id == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(deneyimlerim p)
        {
            deneyimlerim t = repo.Find(x => x.id == p.id);
            t.Baslik = p.Baslik;
            t.altBaslik = p.altBaslik;
            t.tarih = p.tarih;
            t.aciklama = p.aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}