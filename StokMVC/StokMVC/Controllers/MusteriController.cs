using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokMVC.Models.Entity;

namespace StokMVC.Controllers
{
    public class MusteriController : Controller
    {
		// GET: Musteri
		MvcDbStok db = new MvcDbStok();
		public ActionResult Index(string p)
        {
			var degerler = from d in db.TBLMUSTERILER select d;
			if (!string.IsNullOrEmpty(p))
			{
				degerler=degerler.Where(m=>m.MUSTERIAD.Contains(p));
			}
			return View(degerler.ToList());
			//var degerler = db.TBLMUSTERILER.ToList();
			//return View(degerler);
		}
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]

		public ActionResult YeniMusteri(TBLMUSTERILER p1)
		{
			if (!ModelState.IsValid)
			{
				return View("YeniMusteri");
			}
			db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult SIL(int id)
		{
			var musteri = db.TBLMUSTERILER.Find(id);
			db.TBLMUSTERILER.Remove(musteri);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult MusteriGetir(int id)
		{
			var mus = db.TBLMUSTERILER.Find(id);
			return View("MusteriGetir", mus);
		}

		public ActionResult Guncelle(TBLMUSTERILER p1)
		{
			var mstr = db.TBLMUSTERILER.Find(p1.MUSTERIID);
			mstr.MUSTERIAD = p1.MUSTERIAD;
			mstr.MUSTERISOYAD = p1.MUSTERISOYAD;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}