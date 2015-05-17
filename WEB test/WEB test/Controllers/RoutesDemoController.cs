﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OroUostoSistema.Controllers
{
    public class RoutesDemoController : Controller
    {
        //
        // GET: /RoutesDemoController/
        public ActionResult One()
        {
            return View();
        }

        public ActionResult Two(int donuts = 1)
        {
            ViewBag.Donuts = donuts;
            return View();
        }
        [Authorize]
        public ActionResult Three()
        {
            return View();
        }
	}
}