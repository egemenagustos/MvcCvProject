using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<sosyalmedya> repo = new GenericRepository<sosyalmedya>();

        public ActionResult Index()
        {
            var sosyal = repo.List();
            return View(sosyal);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(sosyalmedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x=>x.id == id);
            return View(hesap);
        }

        [HttpPost]
        public ActionResult SayfaGetir(sosyalmedya p)
        {
            var hesap = repo.Find(x => x.id == p.id);
            hesap.ad = p.ad;
            hesap.link = p.link;
            hesap.ikon = p.ikon;
            hesap.durum = true;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.id == id);
            hesap.durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}