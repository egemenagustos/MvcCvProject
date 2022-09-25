using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        GenericRepository<hakkimda> repo = new GenericRepository<hakkimda>();

        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(hakkimda p)
        {
            var t = repo.Find(x => x.id == 1);
            t.ad = p.ad;
            t.soyad = p.soyad;
            t.adres = p.adres;
            t.mail = p.mail;
            t.telefon = p.telefon;
            t.aciklama = p.aciklama;
            t.resim = p.resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}