using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        GenericRepository<egitimlerim> repo = new GenericRepository<egitimlerim>();

        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(egitimlerim p)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.id == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = repo.Find(x=>x.id == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimGetir(egitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            var egitim = repo.Find(x => x.id == p.id);
            egitim.baslik = p.baslik;
            egitim.altBaslik = p.altBaslik;
            egitim.altBaslik2 = p.altBaslik2;
            egitim.tarih = p.tarih;
            egitim.gano = p.gano;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}