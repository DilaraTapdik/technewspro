using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BLL.Repository;

namespace technews.Controllers
{
    public class SharedController : Controller
    {
        public ActionResult KategoriSecim(IEnumerable<int> secilenler = null)
        {
            KategoriRep kr = new KategoriRep();
            return View(kr.GetAll().Select(x => new KategoriViewModel()
            {
                KategoriBaslik = x.KategoriAdi,
                KategoriID = x.KategoriID,
                SeciliMi = secilenler == null ? false : secilenler.Any(a => a == x.KategoriID)
            }).ToList());

        }
    }
}