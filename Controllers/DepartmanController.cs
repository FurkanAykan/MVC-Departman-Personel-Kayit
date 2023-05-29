using Personel_MVC_SQL.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace Personel_MVC_SQL.Controllers
{
    
    [Authorize(Roles = "A,U")] // rolü a ise personel eklesin giriş yapan kişi
    [HandleError]
    public class DepartmanController : Controller
    {
        db_PersonelKYEntities db = new db_PersonelKYEntities();
        //[Authorize] // giriş yapmadan giremez
        
        public ActionResult Index()
        {
            var model = db.Departman.ToList();
            //int a = 10, b = 0;
            //int c = a / b;


            return View(model);
        }
        [HttpGet]
        public ActionResult Yeni()
        {

            return View("DepartmanForm", new Departman());
        }
        //[HttpPost]
        // csrf saldırıları
        [ValidateAntiForgeryToken] // token güvenlik amacıyla yapılır birisi bize bir link yollar ve o linki girip şifremzii çalar ekleme çıkarma yapar yapmasın diye token kullanılır
        public ActionResult Kaydet
            (Departman departman)
        {
            if (ModelState.IsValid == false)
            {
                return View("DepartmanForm");
            }
            if (departman.Id == 0)
            {
                db.Departman.Add(departman);
            }
            else
            {
                var guncellenecekdepartman = db.Departman.Find(departman.Id);
                if (guncellenecekdepartman == null)
                {
                    return HttpNotFound();

                }
                guncellenecekdepartman.Ad = departman.Ad;
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Departman");
        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View("DepartmanForm", model);
        }
        public ActionResult Sil(int id)
        {
            var silinecekdepartman = db.Departman.Find(id);
            if (silinecekdepartman == null)
            {
                return HttpNotFound();
            }
            db.Departman.Remove(silinecekdepartman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}