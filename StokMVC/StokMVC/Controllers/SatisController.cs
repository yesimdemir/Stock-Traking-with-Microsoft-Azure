﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokMVC.Models.Entity;

namespace StokMVC.Controllers
{
    public class SatisController : Controller
    {
		// GET: Satis
		MvcDbStok db = new MvcDbStok();
		public ActionResult Index()
        {
            return View();
        }
        [HttpGet]

		public ActionResult YeniSatis()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YeniSatis(TBLSATISLAR p)
		{
			db.TBLSATISLAR.Add(p);
			db.SaveChanges();
			return View("Index");
		}
	}
}