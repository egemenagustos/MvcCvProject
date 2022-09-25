using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(admin p)
        {
            DbCvEntities db = new DbCvEntities();
            var bilgi = db.admin.FirstOrDefault(x => x.kullaniciAdi == p.kullaniciAdi && x.sifre == p.sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.kullaniciAdi, false);
                Session["kullaniciAdi"] = bilgi.kullaniciAdi.ToString();
                return RedirectToAction("Index","Deneyim");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}