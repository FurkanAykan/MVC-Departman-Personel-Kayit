using Personel_MVC_SQL.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Personel_MVC_SQL.Controllers
{
    
    public class SecurityController : Controller
    {
        db_PersonelKYEntities db = new db_PersonelKYEntities();
        // GET: Security
        [AllowAnonymous] // herkese izin ver dedik global alana tabımladığımız authrozider i engelledik
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous] // herkese izin ver dedik global alana tabımladığımız authrozider i engelledik
        public ActionResult Login(Kullanici kullanici)
        {
            var kullaniciInDb = db.Kullanici.FirstOrDefault(x => x.Ad == kullanici.Ad && x.Sifre == kullanici.Sifre);
            if (kullaniciInDb != null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciInDb.Ad, false); // kullanıcıyı otantike yptık
                return RedirectToAction("Index", "Departman");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanıcı adı veya şifre...";
                return View();
            }


        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}