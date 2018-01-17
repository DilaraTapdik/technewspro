using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using technews.Models;
using Entity;
using BLL;
using Entity.Models;
using static BLL.Repository;

namespace KitapBlog.Controllers
{
    public class KullaniciController : Controller
    {
        private KullaniciRep kRep = new KullaniciRep();

        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kullanici/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici Kullanici = kRep.Find(x => x.KullaniciID == id.Value);
            if (Kullanici == null)
            {
                return HttpNotFound();
            }
            return View(Kullanici);
        }


        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kullanici Kullanici)
        {
            if (ModelState.IsValid)
            {
                if (Session["Kullanici"] == null)
                {
                    kRep.Insert(Kullanici);
                    return RedirectToAction("Index");
                }
            }

            return View(Kullanici);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici Kullanici = kRep.Find(x => x.KullaniciID == id.Value);
            if (Kullanici == null)
            {
                return HttpNotFound();
            }
            return View(Kullanici);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kullanici Kullanici)
        {
            if (ModelState.IsValid)
            {
                Kullanici kul = kRep.Find(x => x.KullaniciID == Kullanici.KullaniciID);
                kul.KullaniciAdi = Kullanici.KullaniciAdi;
                kul.Ad = Kullanici.Ad;
                kul.Sifre = Kullanici.Sifre;
                kul.Soyad = Kullanici.Soyad;
                kul.Email = Kullanici.Email;
                kul.AdminMi = Kullanici.AdminMi;
                kRep.Update(kul);
                return RedirectToAction("Index");
            }
            return View(Kullanici);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici Kullanici = kRep.Find(x => x.KullaniciID == id.Value);
            if (Kullanici == null)
            {
                return HttpNotFound();
            }
            return View(Kullanici);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanici Kullanici = kRep.Find(x => x.KullaniciID == id);
            kRep.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
