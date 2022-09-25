using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();

        public ActionResult Index()
        {
            var degerler = db.hakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.sosyalmedya.Where(x=>x.durum == true).ToList();
            return PartialView(sosyalmedya);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.deneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.egitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.yeteneklerim.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobilerim()
        {
            var hobiler = db.hobilerim.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifikalar()
        {
            var sertifikalar = db.sertifikalarim.ToList();
            return PartialView(sertifikalar);
        }

        [HttpGet]
        public PartialViewResult İletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult İletisim(iletisim p)
        {
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.iletisim.Add(p);
            db.SaveChanges();
            return PartialView();
        }
    }
}