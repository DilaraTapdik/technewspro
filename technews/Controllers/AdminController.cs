using Entity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BLL.Repository;

namespace technews.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //[Authorize(Roles = "admin, habermoderator")]
        public ActionResult HaberEkle()
        {
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "admin, habermoderator")]
        [ValidateAntiForgeryToken]
        public ActionResult HaberEkle(Haber h, List<int> SecilenKategori, HttpPostedFileBase resim)
        {
            var klasor = Server.MapPath("/Content/Upload/");
            if (resim != null && resim.ContentLength != 0)
            {
                if (resim.ContentLength > 2 * 1024 * 1024)
                    ModelState.AddModelError(null, "Resim boyutu max 2MB olabilir.");
                else
                {
                    try
                    {
                        FileInfo fi = new FileInfo(resim.FileName);
                        var rastgele = Guid.NewGuid().ToString().Substring(0, 5);
                        var dosyaAdi = fi.Name + rastgele + fi.Extension;

                        resim.SaveAs(klasor + dosyaAdi);
                        h.ResimURL = dosyaAdi;
                    }
                    catch { }
                }
            }
            if (SecilenKategori != null && SecilenKategori.Count == 0)
                ModelState.AddModelError(string.Empty, "Bir kategori seciniz.");
            try
            {
                KategoriRep kr = new KategoriRep();
                h.Kategorisi = kr.GetAll().Where(x => SecilenKategori.Any(a => a == x.KategoriID)).ToList();
            }
            catch { }
            if (ModelState.IsValid)
            {
                new HaberRep().Insert(h);
                ViewBag.EklendiMi = true;
            }
            return View();
            

        }
    }
}