using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokMVC.Models.Entity;

namespace StokMVC.Controllers
{
    public class ÜrünController : Controller
    {
		// GET: Ürün
		MvcDbStok db = new MvcDbStok();
		public ActionResult Index()
        {
			var degerler = db.TBLURUNLER.ToList();
			return View(degerler);
        }

		[HttpGet]
		public ActionResult YeniUrun()
		{
			List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
											 select new SelectListItem
											 {
												 Text = i.KATEGORIAD,
												 Value = i.KATEGORIID.ToString(),
											 }).ToList();
			ViewBag.dgr=degerler;
			return View();
		}

		[HttpPost]

		public ActionResult YeniUrun(TBLURUNLER p1)
		{
			var ktg=db.TBLKATEGORILER.Where(m=>m.KATEGORIID==p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
			p1.TBLKATEGORILER = ktg;
			db.TBLURUNLER.Add(p1);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult SIL(int id)
		{
			var urun = db.TBLURUNLER.Find(id);
			db.TBLURUNLER.Remove(urun);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult UrunGetir(int id)
		{
			var urun = db.TBLURUNLER.Find(id);

			List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
											 select new SelectListItem
											 {
												 Text = i.KATEGORIAD,
												 Value = i.KATEGORIID.ToString(),
											 }).ToList();
			ViewBag.dgr = degerler;


			return View("UrunGetir",urun);
		}

		public ActionResult Guncelle(TBLURUNLER p1)
		{
			var urn = db.TBLURUNLER.Find(p1.URUNID);
			urn.URUNAD= p1.URUNAD;
			urn.MARKA= p1.MARKA;
			urn.FIYAT= p1.FIYAT;
			urn.STOK= p1.STOK;
			//urn.URUNKATEGORI= p1.URUNKATEGORI;

			var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
			urn.URUNKATEGORI = ktg.KATEGORIID;

			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}