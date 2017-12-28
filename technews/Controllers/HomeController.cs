using DAL;
using Entity.Models;
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
            return View();
        }
        HaberRep hr = new HaberRep();
        public PartialViewResult GuncelHaberler()
        {
            
            IEnumerable<Haber> liste = hr.GetAll().OrderByDescending(x => x.EklemeTarihi).Take(4);
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
}