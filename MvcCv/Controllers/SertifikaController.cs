using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<sertifikalarim> repo = new GenericRepository<sertifikalarim>();

        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x=>x.id == id);
            ViewBag.d = id;
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(sertifikalarim p)
        {
            var sertifika = repo.Find(x => x.id == p.id);
            sertifika.aciklama = p.aciklama;
            sertifika.tarih = p.tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(sertifikalarim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x=>x.id == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}