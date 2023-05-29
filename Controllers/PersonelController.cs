using Personel_MVC_SQL.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity; // Include çalışsın diye tanımladık
using Personel_MVC_SQL.ViewModels;

namespace Personel_MVC_SQL.Controllers
{
    [Authorize(Roles = "A,U")] // rolü a ise personel eklesin giriş yapan kişi
    public class PersonelController : Controller
    {
        db_PersonelKYEntities db = new db_PersonelKYEntities();
        // GET: Personel
        [OutputCache(Duration =30)] // sürekli database e gitme 30 sn ilk getirdiğin verileri tut dedik.
        public ActionResult Index()
        {
            var model = db.Personel.Include(x => x.Departman).ToList(); // lazzy loading ve eager kavramı için yaptık yani bunu yapmasaydık departman adını yazdırırken sql e 4 sorgu atıp bize geri dönüş yapacaktı fakat bunu yapınca tek sorgu da bize verileri getirdi performansı arttırdı. personellerin içine departmanı joın etmiş olduk
            return View(model);
        }

        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = new Personel()
            };

            return View("PersonelForm", model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if (ModelState.IsValid == false)
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = db.Departman.ToList(),
                    Personel = personel
                };


                return View("PersonelForm", model);
            }
            if (personel.Id == 0)
            {
                db.Personel.Add(personel);
            }
            else // güncelleme
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified; // kısa yoldan güncelleme
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = db.Personel.Find(id)
            };

            return View("PersonelForm", model);
        }
        public ActionResult Sil(int id)
        {
            var silinecekpersonel = db.Personel.Find(id);

            if (silinecekpersonel == null)
            {
                return HttpNotFound();
            }
            db.Personel.Remove(silinecekpersonel);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult PersonelleriListele(int id)
        {
            var model = db.Personel.Where(x => x.DepartmanId == id).ToList();
            return PartialView(model);
        }
        public int? ToplamMaas()
        {
            return db.Personel.Sum(x => x.Maas);
        }
    }
}