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
    public class HaberController : Controller
    {
        // GET: Haber
        public ActionResult Index()
        {
            HaberRep hr = new HaberRep();
            IEnumerable<Haber> liste = hr.GetAll().OrderBy(x => x.Title);
            return View(liste);
        }
        public ActionResult Gundem()
        {
            HaberRep hr = new HaberRep();
            IEnumerable<Haber> liste = hr.GetAll().OrderBy(x => x.EklemeTarihi).Take(10);
            return View(liste);
        }
        [HttpGet]
        [Authorize(Roles = "Admin, HaberModerator")]
        public ActionResult HaberEkle()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin, HaberModerator")]
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



        [HttpGet]
        [Authorize(Roles = "Admin, HaberModerator")]
        public ActionResult Duzenle(int id)
        {
            HaberRep rep = new HaberRep();
            return View(rep.GetById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, MakaleModerator")]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Haber h, HttpPostedFileBase HaberURL, List<int> SecilenKategori)
        {
            if (SecilenKategori == null || SecilenKategori.Count == 0)
                ModelState.AddModelError(string.Empty, "Bir kategori seciniz.");

            if (ModelState.IsValid)
            {
                HaberRep er = new HaberRep();

                Haber haber = er.GetById(h.HaberID);

                haber.Title = h.Title;
                haber.Content = h.Content;
                KategoriRep kr = new KategoriRep();
                haber.Kategorisi = new List<Kategori>();
                haber.Kategorisi.AddRange(kr.GetAll().Where(x => SecilenKategori.Any(a => a == x.KategoriID)).ToList());

                er.Update(haber);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Detay(int id)
        {
            ViewBag.gelen = "Haber";
            HaberRep hr = new HaberRep();
            Haber h = hr.GetById(id);
            h.GoruntulenmeSayisi++;
            return View(h);
        }

        [Authorize(Roles = "Admin, MakaleModerator")]
        [HttpPost]
        public JsonResult HaberSil(int id)
        {
            try
            {
                new HaberRep().Delete(id);
                return Json(new { success = true, message = "Silindi" });
            }
            catch
            {
                return Json(new { success = false, message = "Bir hata oluştu." });
            }
        }
    }
}
