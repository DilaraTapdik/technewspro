using BLL;
using DAL;
using Entity.Models;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BLL.Repository;

namespace technews.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Haber> liste = hr.GetAll().OrderByDescending(x => x.GoruntulenmeSayisi).Take(8);
            return View(liste);
        }
        HaberRep hr = new HaberRep();
        public PartialViewResult GuncelHaberler()
        {
            IEnumerable<Haber> liste = hr.GetAll().OrderByDescending(x => x.EklemeTarihi).Take(4);
            return PartialView(liste);
        }
        public PartialViewResult Slider()
        {
            IEnumerable<Haber> liste = hr.GetAll().OrderByDescending(x => x.EklemeTarihi).Take(3);
            return PartialView(liste);
        }
        public PartialViewResult Arsivler()
        {
            IEnumerable<Haber> liste = hr.GetAll().OrderByDescending(x => x.EklemeTarihi).Take(4);
            return PartialView(liste);
        }
        public PartialViewResult Kategoriler()
        {
            KategoriRep kr = new KategoriRep();
            IEnumerable<Kategori> liste = kr.GetAll().OrderByDescending(x => x.KategoriAdi).Take(6);
            return PartialView(liste);
        }

        public ActionResult Hakkımızda()
        {
            return View();
        }
        public ActionResult Giris()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Giris(GirisView model)
        {
            if (ModelState.IsValid)
            {
                KullaniciRep kRep = new KullaniciRep();
                Kullanici kul = kRep.Find(x => x.KullaniciAdi == model.KullaniciAdi);
                KullaniciYonetimi kYon = new KullaniciYonetimi();
                kYon.KullaniciGiris(model);
                Session["kullanici"] = kul;

                return RedirectToAction("Index");

            }
            return View(model);
        }
        public ActionResult Cikis()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult KayitOl()
        {

            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(KayıtView model)
        {

            if (ModelState.IsValid)
            {
                KullaniciYonetimi kYon = new KullaniciYonetimi();
                kYon.KullaniciYonetim(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
    //public ActionResult About()
    //{
    //    ViewBag.Message = "Your application description page.";

    //    return View();
    //}

    //public ActionResult Contact()
    //{
    //    ViewBag.Message = "Your contact page.";

    //    return View();
    //}
}
